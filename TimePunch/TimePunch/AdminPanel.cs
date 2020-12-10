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
    public partial class AdminPanel : UserControl
    {
        private MainForm mainForm;
        private Auth auth;


        public AdminPanel(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.SETTINGS);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.USERS);
        }

        private void usersHoursButton_Click(object sender, EventArgs e)
        {
            mainForm.changeView(MainForm.Views.USERS_HOURS);
        }
    }
}
