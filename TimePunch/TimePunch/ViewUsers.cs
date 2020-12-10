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
    public partial class ViewUsers : UserControl
    {
        Auth auth;
        MainForm mainForm;

        public ViewUsers(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            //get list of users
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var users = (from user in dbcontext.Users
                         orderby user.LastName, user.FirstName
                         select user).ToArray();

            usersFlowLayout.Controls.Add(new UserLabelTitle());

            foreach(var user in users)
            {
                UserLabel userLabel = new UserLabel(mainForm, user);
                usersFlowLayout.Controls.Add(userLabel);
            }

            dbcontext.Dispose();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.ADD_EDIT_USER);
        }
    }
}
