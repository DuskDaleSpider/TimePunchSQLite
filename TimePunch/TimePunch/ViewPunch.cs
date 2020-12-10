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
    public partial class ViewPunch : UserControl
    {

        private Auth auth;
        private MainForm mainForm;
        private int punchID;

        public ViewPunch(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
            this.punchID = 0;
        }

        public ViewPunch(Auth auth, MainForm mainForm, int punchID)
        {
            this.auth = auth;
            this.mainForm = mainForm;
            this.punchID = punchID;
            InitializeComponent();
        }

        private void ViewToday_Load(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();
            TimePunchDatabase.TimePunch[] openPunch;
            if(this.punchID == 0)
            {
                string todaysDate = DateTime.Today.ToString("o");
                openPunch = (from punch in dbcontext.TimePunches
                 where punch.UserID == auth.User.ID &&
                       punch.Date == todaysDate
                 select punch).ToArray();
            }
            else
            {
                openPunch = (from punch in dbcontext.TimePunches
                             where punch.ID == this.punchID
                             select punch).ToArray();
            }

            if (openPunch.Length > 0)
            {
                var punch = openPunch[0];

                punchBox.Text = Convert.ToDateTime(punch.Date).ToShortDateString();

                //set the outputlabels
                if (punch.PunchIn != null)
                {
                    punchInOutputLabel.Text = DateTime.Today.Add(Convert.ToDateTime(punch.PunchIn).TimeOfDay).ToShortTimeString();
                }
                else
                {
                    punchInOutputLabel.Text = "N/A";
                }

                if (punch.LunchStart != null)
                {
                    lunchStartOutputLabel.Text = DateTime.Today.Add(Convert.ToDateTime(punch.LunchStart).TimeOfDay).ToShortTimeString();
                }
                else
                {
                    lunchStartOutputLabel.Text = "N/A";
                }

                if (punch.LunchEnd != null)
                {
                    lunchEndOutputLabel.Text = DateTime.Today.Add(Convert.ToDateTime(punch.LunchEnd).TimeOfDay).ToShortTimeString();
                }
                else
                {
                    lunchEndOutputLabel.Text = "N/A";
                }

                if (punch.PunchOut != null)
                {
                    punchOutOutputLabel.Text = DateTime.Today.Add(Convert.ToDateTime(punch.PunchOut).TimeOfDay).ToShortTimeString();
                }
                else
                {
                    punchOutOutputLabel.Text = "N/A";
                }

                //set outputlabels visible
                punchInOutputLabel.Visible = true;
                lunchStartOutputLabel.Visible = true;
                lunchEndOutputLabel.Visible = true;
                punchOutOutputLabel.Visible = true;
            }
        }

        //back button 
        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }
    }
}
