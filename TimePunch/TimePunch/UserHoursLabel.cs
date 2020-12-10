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
    public partial class UserHoursLabel : UserControl
    {
        private MainForm mainForm;
        private TimePunchDatabase.User user;
        private double hours;

        public UserHoursLabel(MainForm mainForm, TimePunchDatabase.User user, double hours)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.user = user;
            this.hours = hours;

            nameLabel.Text = user.LastName + ", " + user.FirstName;
            usernameLabel.Text = user.Username;
            hoursLinkLabel.Text = String.Format("{0:N2}", hours);
        }

        private void hoursLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.changeView(MainForm.Views.VIEW_HOURS, (int)user.ID);
        }
    }
}
