using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TimePunch
{
    public partial class TimePunch : UserControl
    {
        private Auth auth;
        private MainForm mainForm;

        public TimePunch(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void punchInButton_Click(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            string todaysDate = DateTime.Today.ToString("o");

            //see if the user has an open punch already
            var openPunch = (from punch in dbcontext.TimePunches
                            where punch.UserID == auth.User.ID && punch.isOpen == 1 ||
                                  punch.UserID == auth.User.ID && punch.Date == todaysDate && punch.isOpen == 0
                            select punch).ToArray();

            if(openPunch.Length > 0)
            {
                MessageBox.Show("You have already clocked in for the day!", "Punch In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Generate SQL for TimePunch Insertion

            string date = DateTime.Today.Date.ToString("o");
            string punchIn = DateTime.Now.ToString("o");

            SQLiteConnection conn = new SQLiteConnection("DataSource=./TimePunchV2.db");
            conn.Open();

            string sql = string.Format("INSERT INTO TimePunches (UserID, isOpen, Date, PunchIn) VALUES" +
                "({0}, {1}, \"{2}\", \"{3}\");", auth.User.ID, 1, date, punchIn);
            SQLiteCommand command = new SQLiteCommand(sql, conn);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("You have clocked in!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Could not update punch. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dbcontext.Dispose();
            }

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            auth.Logout();
            mainForm.changeView(MainForm.Views.LOGIN);

        }

        private void lunchStartButton_Click(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            //find open punch
            var openPunch = (from punch in dbcontext.TimePunches
                            where punch.UserID == auth.User.ID &&
                                  punch.isOpen == 1
                            select punch).ToArray();
            if(openPunch.Length > 0)
            { 
                var punch = openPunch[0];

                //check if they have already started lunch
                if(punch.LunchStart == null)
                {
                    //set lunch start in punch and update database
                    punch.LunchStart = DateTime.Now.ToString("o");

                    try
                    {
                        dbcontext.SaveChanges();
                        MessageBox.Show("Your lunch has started!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Unable to start lunch. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        dbcontext.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("You have already started a lunch!", "Lunch Start", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                
                
            }
            else
            {
                MessageBox.Show("You haven't clocked in yet!", "Lunch Start", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void lunchEndButton_Click(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            //find an open punch
            var openPunch = (from punch in dbcontext.TimePunches
                             where punch.UserID == auth.User.ID &&
                                   punch.isOpen == 1
                             select punch).ToArray();
            //get settings
            var settings = (from setting in dbcontext.Settings
                            where setting.ID == 1
                            select setting).ToArray();


            if(openPunch.Length > 0)
            {
                var punch = openPunch[0];

                //check if they have already ended thier lunch
                if(punch.LunchEnd == null)
                {
                    //check if they started their lunch
                    if(punch.LunchStart != null)
                    {
                        //check if the minimum amount of minutes has passed
                        long currentUnixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
                        long lunchStartUnixTime = ((DateTimeOffset)DateTime.Today.Add(Convert.ToDateTime(punch.LunchStart).TimeOfDay).ToUniversalTime()).ToUnixTimeSeconds();
                        long timeDiff = (currentUnixTime - lunchStartUnixTime) / 60;
                        //add a LunchEnd punch
                        if (timeDiff >= settings[0].minimumLunchMins)
                        {

                            punch.LunchEnd = DateTime.Now.ToString("o");

                            try
                            {
                                dbcontext.SaveChanges();
                                MessageBox.Show("You have clocked in from lunch!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                MessageBox.Show("Could not punch in from lunch. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            finally
                            {
                                dbcontext.Dispose();
                            }
                        }
                        else
                        {
                            MessageBox.Show("You need a minimum of " + settings[0].minimumLunchMins + " mins on your lunch", "End Lunch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have not started your lunch yet", "End Lunch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You have already ended your lunch!", "End Lunch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You are not clocked in!", "End Lunch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void punchOutButton_Click(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            //find open punch
            var openPunch = (from punch in dbcontext.TimePunches
                             where punch.UserID == auth.User.ID &&
                                   punch.isOpen == 1
                             select punch).ToArray();

            if(openPunch.Length > 0)
            {
                var punch = openPunch[0];
                //check if they are still on lunch
                if(!(punch.LunchStart != null && punch.LunchEnd == null))
                {
                    //and a punch out and close the punch
                    punch.PunchOut = DateTime.Now.ToString("o");
                    punch.isOpen = 0;

                    try
                    {
                        dbcontext.SaveChanges();
                        MessageBox.Show("You have punched out!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                        MessageBox.Show("Could not punch out. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You are still on lunch!", "Punch Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You have not clocked in!", "Punch Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.VIEW_TODAY);
        }

        private void TimePunch_Load(object sender, EventArgs e)
        {
            if(auth.User.Role == 0)
            {
                adminButton.Visible = true;
            }
            else
            {
                adminButton.Visible = false;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.SETTINGS);
        }

        private void viewHoursButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.VIEW_HOURS);
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.ADMIN);
        }
    }
}
