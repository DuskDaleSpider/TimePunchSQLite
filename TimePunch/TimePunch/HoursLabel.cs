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
    public partial class HoursLabel : UserControl
    {

        private DateTime date;
        private double hours;
        private MainForm mainForm;
        private int punchID;

        public HoursLabel(DateTime date, double hours, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.date = date;
            this.hours = hours;
            this.punchID = 0;
        }

        public HoursLabel(DateTime date, double hours, MainForm mainForm, int punchID)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.date = date;
            this.hours = hours;
            this.punchID = punchID;
        }

        private void hoursLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mainForm.changeView(MainForm.Views.VIEW_PUNCH, punchID);
        }

        private void HoursLabel_Load(object sender, EventArgs e)
        {
            dateLabel.Text = this.date.ToShortDateString();
            hoursLinkLabel.Text = String.Format("{0:N2}", this.hours);
        }
    }
}
