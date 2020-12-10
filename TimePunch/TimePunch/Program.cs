using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePunch
{
    static class Program
    {
        static Random random = new Random();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Temp for testing purpose
            try
            {
                TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

                var users = (from user in dbcontext.Users
                             select user).ToArray();
                if (users.Length == 0)
                    InsertTestData(dbcontext);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                if(ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void InsertTestData(TimePunchDatabase.TimePunchEntities dbcontext)
        {
            TimePunchDatabase.User newUser = new TimePunchDatabase.User();
            PasswordHash ph = new PasswordHash("admin");

            //admin
            newUser.Username = "admin";
            newUser.Password = Convert.ToBase64String(ph.ToArray());
            newUser.Role = 0;
            newUser.FirstName = "Admin";
            newUser.LastName = "smith";

            dbcontext.Users.Add(newUser);

            try
            {
                dbcontext.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Unable to save new user to database");
            }

            //Bypassing ADO because adding multiple rows results in unique constraint errors from db
            SQLiteConnection conn = new SQLiteConnection("DataSource=./TimePunchV2.db");
            conn.Open();
            string sql = "BEGIN TRANSACTION; ";

            //test users
            string[] firstNames = { "Dakota", "Anna", "Jordan", "John", "Dillon", "Tony", "Shinji", "Asuka" };
            string[] lastNames = { "Clark", "Mazer", "Packard", "Smith", "Burns", "Stark", "Ikari", "Soryu"};
            TimePunchDatabase.User[] newUsers = new TimePunchDatabase.User[firstNames.Length];

            for(int i = 0; i < firstNames.Length; i++)
            {
                string username = firstNames[i] + lastNames[i];
                string password = Convert.ToBase64String(new PasswordHash(username).ToArray());

                sql += String.Format("INSERT INTO Users (Username, Password, FirstName, LastName, Role) VALUES" +
                    "(\"{0}\", \"{1}\", \"{2}\", \"{3}\", {4});", username, password, firstNames[i], lastNames[i], 1);
            }

            sql += "COMMIT;";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();


            //get all the created users
            var users = from user in dbcontext.Users
                        where user.Username != "admin"
                        select user;

            sql = "BEGIN TRANSACTION;";

            //test TimePunches for test users
            foreach(var user in users)
            { 
                for (int i = 8; i > 1; i--)
                {
                    TimePunchDatabase.TimePunch newPunch = new TimePunchDatabase.TimePunch();
                    //get random punch times
                    double[] times = new double[4];
                    times = getRandomTimes();

                    newPunch.UserID = user.ID;
                    newPunch.Date = DateTime.Today.Date.Subtract(new TimeSpan(i, 0, 0, 0)).ToString("O");
                    newPunch.PunchIn = Convert.ToDateTime(newPunch.Date).AddHours(times[0]).ToString("o");
                    newPunch.LunchStart = Convert.ToDateTime(newPunch.Date).AddHours(times[1]).ToString("o");
                    newPunch.LunchEnd = Convert.ToDateTime(newPunch.Date).AddHours(times[2]).ToString("o");
                    newPunch.PunchOut = Convert.ToDateTime(newPunch.Date).AddHours(times[3]).ToString("o");
                    newPunch.isOpen = 0;

                    sql += string.Format("INSERT INTO TimePunches (UserID, Date, PunchIn, LunchStart, LunchEnd, PunchOut, isOpen) VALUES " +
                        "({0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", 0);", newPunch.UserID, newPunch.Date, newPunch.PunchIn, newPunch.LunchStart, newPunch.LunchEnd, newPunch.PunchOut);
                }
            }

            sql += "COMMIT;";
            command.CommandText = sql;
            command.ExecuteNonQuery();


            //change start date in settings for 7 days before today
            string payPeriodStartDate = DateTime.Today.Subtract(new TimeSpan(6, 0, 0, 0)).ToString("o");
            command.CommandText = "UPDATE Settings SET payPeriodStartDate=\"" + payPeriodStartDate + "\" WHERE ID=1;";
            command.ExecuteNonQuery();

            conn.Close();
            dbcontext.Dispose();


        }

        public static double[] getRandomTimes()
        {
            double[] times = new double[4];

            times[0] = random.NextDouble() * (13 - 1) + 1; //get a time between 1am and 12 pm
            times[1] = times[0] + (random.NextDouble() * (6 - 4) + 4);//get a time that's 6-4 hours after first time
            times[2] = random.Next(2) == 0 ? times[1] + .5 : times[1] + 1; //get either half an hour or whole hour for lunch
            times[3] = times[2] + (random.NextDouble() * (4 - 2) + 2); //get a time thats 2-4 hours after lunch
            return times;
        }
    }
}
