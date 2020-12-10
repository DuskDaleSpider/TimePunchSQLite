using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePunch
{
    public partial class UserLabel : UserControl
    {
        private MainForm mainForm;
        private TimePunchDatabase.User user;
        private string[] roles = { "Admin", "User" };

        public UserLabel(MainForm mainForm, TimePunchDatabase.User user)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.user = user;
        }

        private void UserLabel_Load(object sender, EventArgs e)
        {
            nameLabel.Text = user.LastName + ", " + user.FirstName;
            usernameLabel.Text = user.Username;
            roleLabel.Text = roles[user.Role];

            nameLabel.Visible = true;
            usernameLabel.Visible = true;
            roleLabel.Visible = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(result == DialogResult.Yes)
            {
                TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();
                var deluser = (from u in dbcontext.Users
                               where u.ID == user.ID
                               select u).First();

                var userPunches = from punch in dbcontext.TimePunches
                                  where punch.UserID == user.ID
                                  select punch;

                //remove all timepunhes from user
                foreach(var punch in userPunches)
                {
                    dbcontext.TimePunches.Remove(punch);
                }
                //remove user
                try
                {
                    dbcontext.Users.Remove(deluser);
                    dbcontext.SaveChanges();
                    MessageBox.Show("User has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("User could not be deleted. Try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    dbcontext.Dispose();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.ADD_EDIT_USER, (int)user.ID);
        }
    }
}
