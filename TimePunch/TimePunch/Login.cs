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
    public partial class Login : UserControl
    {
        private Auth auth;
        private MainForm mainForm;

        public Login()
        {
            InitializeComponent();
        }

        public Login(Auth auth, MainForm mainForm)
        {
            InitializeComponent();
            this.auth = auth;
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
            if (auth.isLoggedIn)
            {
                mainForm.changeView(MainForm.Views.TIME_PUNCH); 
            }
        }

        public void login()
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            
            if (auth.Authenticate(username, password))
            {
                String firstName = auth.User.FirstName;
                outputLabel.Text = string.Format("Welcome {0}. You have been logged in!", firstName);
            }
            else
            {
                outputLabel.Text = "Username or Password is incorrect.";
            }

            outputLabel.Visible = true;

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.SuppressKeyPress = true;
            }
            if (auth.isLoggedIn)
                mainForm.changeView(MainForm.Views.TIME_PUNCH);
        }
    }
}
