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
    public partial class ViewUsersHours : UserControl
    {
        private Auth auth;
        private MainForm mainForm;

        public ViewUsersHours(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }

        private void ViewUsersHours_Load(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();
            //get settings
            var settings = (from setting in dbcontext.Settings
                            where setting.ID == 1
                            select setting).First();

            //get all users
            var users = (from user in dbcontext.Users
                         orderby user.LastName, user.FirstName
                         select user);

            userHoursFlowLayout.Controls.Add(new UserHoursLabelTitle());

            foreach(var user in users)
            {
                //get all timepunches from pay period for user
                TimeSpan daysPassed = DateTime.Today.Subtract(Convert.ToDateTime(settings.payPeriodStartDate).Date);
                int daysIntoPayPeriod = (int)Math.Floor(daysPassed.TotalDays % settings.payPeriodDays);

                DateTime payPeriodStartDate = DateTime.Today.Subtract(new TimeSpan(daysIntoPayPeriod, 0, 0, 0));

                //another bypass because of dates
                SQLiteConnection conn = new SQLiteConnection("DataSource=./TimePunchV2.db");
                conn.Open();
                string sql = String.Format("SELECT * FROM TimePunches " +
                    "WHERE UserID = " + user.ID + " AND Date >= \"" + payPeriodStartDate.ToString("o") + "\";");
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = command.ExecuteReader();

                double totalHours = 0;

                //tally total hours for user in payperiod
                while (reader.Read())
                {
                    if (reader["LunchStart"] != DBNull.Value && reader["LunchEnd"] != DBNull.Value && reader["PunchOut"] != DBNull.Value)
                    {
                        totalHours += DateTime.Today.Add(Convert.ToDateTime(reader["PunchOut"]).TimeOfDay)
                            .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["LunchEnd"]).TimeOfDay)).TotalHours;
                        totalHours += DateTime.Today.Add(Convert.ToDateTime(reader["LunchStart"]).TimeOfDay)
                            .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours;
                    }
                    else if (reader["LunchStart"] == DBNull.Value && reader["LunchEnd"] == DBNull.Value && reader["PunchOut"] != DBNull.Value)
                    {
                        totalHours += DateTime.Today.Add(Convert.ToDateTime(reader["PunchOut"]).TimeOfDay)
                            .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours;
                    }
                    else if (reader["LunchStart"] != DBNull.Value && reader["LunchEnd"] == DBNull.Value)
                    {
                        totalHours += DateTime.Today.Add(Convert.ToDateTime(reader["LunchStart"]).TimeOfDay)
                            .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours;
                    }
                }

                conn.Close();

                //Add UserHoursLabel for user
                UserHoursLabel userHoursLabel = new UserHoursLabel(this.mainForm, user, totalHours);
                userHoursFlowLayout.Controls.Add(userHoursLabel);

            }

            dbcontext.Dispose();
        }
    }
}
