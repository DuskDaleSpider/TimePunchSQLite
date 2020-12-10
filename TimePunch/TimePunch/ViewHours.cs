using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePunch
{
    public partial class ViewHours : UserControl
    {
        Auth auth;
        MainForm mainForm;
        int userID;

        public ViewHours(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
            this.userID = 0;
        }

        public ViewHours(Auth auth, MainForm mainForm, int ID)
            :this(auth, mainForm)
        {
            this.userID = ID;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ViewHours_Load(object sender, EventArgs e)
        {

            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var settings = (from setting in dbcontext.Settings
                            where setting.ID == 1
                            select setting).First();

            DateTime currentDate = DateTime.Today;
            DateTime payPeriodStart = Convert.ToDateTime(settings.payPeriodStartDate).Date;

            double daysPassed = currentDate.Subtract(payPeriodStart).TotalDays;

            int daysIntoPayperiod = (int)Math.Floor(daysPassed % settings.payPeriodDays);

            DateTime firstDay = DateTime.Today.Subtract(new TimeSpan(daysIntoPayperiod, 0, 0, 0));
            string firstDayString = firstDay.ToString("o");

            //bypass ADO to compare dates since you can't compare >= with strings and you can't use outside functions with linq. ;-;
            SQLiteConnection conn = new SQLiteConnection("DataSource=./TimePunchV2.db");
            conn.Open();
            string sql = "SELECT * FROM TimePunches " +
                "WHERE UserID = " + (this.userID == 0 ? auth.User.ID : this.userID) + " AND " +
                "Date >= \"" + firstDayString + "\"";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                double hours = 0;

                //half day
                if(reader["LunchStart"] == DBNull.Value && reader["LunchEnd"] == DBNull.Value && reader["PunchOut"] != DBNull.Value)
                {
                    hours = DateTime.Today.Add(Convert.ToDateTime(reader["PunchOut"]).TimeOfDay)
                        .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours; 
                }//full day
                else if(reader["LunchStart"] != DBNull.Value && reader["LunchEnd"] != DBNull.Value && reader["PunchOut"] != DBNull.Value)
                {
                    hours = DateTime.Today.Add(Convert.ToDateTime(reader["PunchOut"]).TimeOfDay)
                        .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["LunchEnd"]).TimeOfDay)).TotalHours;
                    hours += DateTime.Today.Add(Convert.ToDateTime(reader["LunchStart"]).TimeOfDay)
                        .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours;
                }//on lunch
                else if(reader["LunchStart"] != DBNull.Value && reader["LunchEnd"] == DBNull.Value)
                {
                    hours = DateTime.Today.Add(Convert.ToDateTime(reader["LunchStart"]).TimeOfDay)
                        .Subtract(DateTime.Today.Add(Convert.ToDateTime(reader["PunchIn"]).TimeOfDay)).TotalHours;
                }

                HoursLabel hoursLabel = new HoursLabel(Convert.ToDateTime(reader["Date"]), hours, mainForm, Convert.ToInt32(reader["ID"]));
                hoursFlowLayoutPanel.Controls.Add(hoursLabel);
            }

            conn.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }
    }
}
