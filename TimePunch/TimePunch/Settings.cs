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
    public partial class Settings : UserControl
    {
        private Auth auth;
        private MainForm mainForm;


        public Settings(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.PreviousView();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //populate fields with current settings
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var settings = (from setting in dbcontext.Settings
                           where setting.ID == 1
                           select setting).ToArray();

            if(settings.Length > 0)
            {
                minLunchInput.Value = settings[0].minimumLunchMins;
                payPeriodStartCalander.SelectionStart = Convert.ToDateTime(settings[0].payPeriodStartDate);
                payPeriodStartCalander.SelectionEnd = Convert.ToDateTime(settings[0].payPeriodStartDate);
                payPeriodLengthInput.Value = settings[0].payPeriodDays;
            }

            dbcontext.Dispose();

        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var settings = (from setting in dbcontext.Settings
                            where setting.ID == 1
                            select setting).ToArray();

            if(settings.Length > 0)
            {
                settings[0].minimumLunchMins = (int)minLunchInput.Value;
                settings[0].payPeriodStartDate = payPeriodStartCalander.SelectionStart.ToString("o");
                settings[0].payPeriodDays = (int)payPeriodLengthInput.Value;
            }
            else
            {
                TimePunchDatabase.Setting newSettings = new TimePunchDatabase.Setting();
                newSettings.minimumLunchMins = (int)minLunchInput.Value;
                newSettings.payPeriodStartDate = payPeriodStartCalander.SelectionStart.ToString("o");
                newSettings.payPeriodDays = (int)payPeriodLengthInput.Value;
                dbcontext.Settings.Add(newSettings);
            }

            try
            {
                dbcontext.SaveChanges();
                MessageBox.Show("Settings have been saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show("Settings could not be saved. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dbcontext.Dispose();
            }
        }
    }
}
