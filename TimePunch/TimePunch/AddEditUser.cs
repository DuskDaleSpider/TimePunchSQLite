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
    public partial class AddEditUser : UserControl
    {
        private MainForm mainForm;
        private int userID;
        private bool isEdit;

        public AddEditUser(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.isEdit = false;
        }

        public AddEditUser(MainForm mainForm, int userID)
            :this(mainForm)
        {
            this.userID = userID;
            addButton.Text = "Apply";
            this.isEdit = true;
            //load user for edit
            loadUserValues();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                addUser();
                return;
            }

            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();
            TimePunchDatabase.User user;
           
            user = (from u in dbcontext.Users
                    where u.ID == this.userID
                    select u).First();

            user.Username = usernameTextBox.Text.Trim();
            if (!isEdit || passwordTextBox.Text.Trim() != "")
                user.Password = Convert.ToBase64String(new PasswordHash(passwordTextBox.Text.Trim()).ToArray());
            user.FirstName = firstNameTextBox.Text;
            user.LastName = lastNameTextBox.Text;
            user.Role = roleComboBox.SelectedIndex;

            try
            {
                dbcontext.SaveChanges();
                MessageBox.Show("User has been saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                MessageBox.Show("User could not be saved. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dbcontext.Dispose();
            }
        }

        private void loadUserValues()
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var userData = (from user in dbcontext.Users
                            where user.ID == userID
                            select user).First();

            usernameTextBox.Text = userData.Username;
            firstNameTextBox.Text = userData.FirstName;
            lastNameTextBox.Text = userData.LastName;
            roleComboBox.SelectedIndex = (int)userData.Role;

            dbcontext.Dispose();
        }

        //for some reason, can not add a new user with ADO sooo SQL it is
        private void addUser()
        {
            string username = usernameTextBox.Text.Trim();
            string password = Convert.ToBase64String(new PasswordHash(passwordTextBox.Text.Trim()).ToArray());
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            int role = roleComboBox.SelectedIndex == -1 ? 1 : roleComboBox.SelectedIndex;

            using (SQLiteConnection conn = new SQLiteConnection("DataSource=./TimePunchV2.db")) {
                try
                {
                    conn.Open();
                    string sql = String.Format("INSERT INTO Users (Username, Password, FirstName, LastName, Role) VALUES " +
                        "(\"{0}\", \"{1}\", \"{2}\", \"{3}\", {4});", username, password, firstName, lastName, role);
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();

                    MessageBox.Show("User has been saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("User could not be saved. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Console.WriteLine(ex.Message);
                    Exception inner = ex.InnerException;
                    while(inner != null)
                    {
                        Console.WriteLine(inner.Message);
                        inner = inner.InnerException;
                    }
                }
            }

        }


        /*TODO: CLEAN UP*/
        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void roleLabel_Click(object sender, EventArgs e)
        {

        }

        private void roleComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(roleComboBox.Text != "")
            {
                roleComboBox.Text = "";
            }
        }
    }
}
