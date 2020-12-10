using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimePunch
{
    public partial class MainForm : Form
    {
        private Auth auth;
        private Stack<PrevView> prevViews = new Stack<PrevView>();
        private Views currentView;
        private int currentArg;
        private bool goingBack = false;

        public enum Views
        {
            LOGIN,
            TIME_PUNCH,
            VIEW_TODAY,
            SETTINGS,
            VIEW_HOURS,
            VIEW_PUNCH,
            ADMIN,
            USERS,
            ADD_EDIT_USER,
            USERS_HOURS
        }

        public MainForm()
        {
            InitializeComponent();
            auth = new Auth();
            changeView(Views.LOGIN);
        }

        public void changeView(Views view)
        {
            contentPanel.Controls.Clear();
            if(!this.goingBack)
                this.prevViews.Push(new PrevView(this.currentView, 0));
            this.currentView = view;
            this.currentArg = 0;


            switch (view)
            {
                case Views.LOGIN:
                    contentPanel.Controls.Add(new Login(auth, this));
                    break;
                case Views.TIME_PUNCH:
                    contentPanel.Controls.Add(new TimePunch(auth, this));
                    break;
                case Views.VIEW_TODAY:
                    contentPanel.Controls.Add(new ViewPunch(auth, this));
                    break;
                case Views.SETTINGS:
                    contentPanel.Controls.Add(new Settings(auth, this));
                    break;
                case Views.VIEW_HOURS:
                    contentPanel.Controls.Add(new ViewHours(auth, this));
                    break;
                case Views.USERS:
                    contentPanel.Controls.Add(new ViewUsers(auth, this));
                    break;
                case Views.ADMIN:
                    contentPanel.Controls.Add(new AdminPanel(auth, this));
                    break;
                case Views.ADD_EDIT_USER:
                    contentPanel.Controls.Add(new AddEditUser(this));
                    break;
                case Views.USERS_HOURS:
                    contentPanel.Controls.Add(new ViewUsersHours(auth, this));
                    break;
            }
            this.goingBack = false;
        }
        
        public void changeView(Views view, int ID)
        {
            contentPanel.Controls.Clear();
            if (!this.goingBack)
                this.prevViews.Push(new PrevView(this.currentView, this.currentArg));
            this.currentView = view;
            this.currentArg = ID;

            switch (view)
            {
                case Views.VIEW_PUNCH:
                    contentPanel.Controls.Add(new ViewPunch(auth, this, ID));
                    break;
                case Views.ADD_EDIT_USER:
                    contentPanel.Controls.Add(new AddEditUser(this, ID));
                    break;
                case Views.VIEW_HOURS:
                    contentPanel.Controls.Add(new ViewHours(auth, this, ID));
                    break;
            }
            this.goingBack = false;
        }

        public void PreviousView()
        {
            this.goingBack = true;
            PrevView prevView = prevViews.Pop();
            if(prevView.Arg == 0)
            {
                changeView(prevView.View);
            }
            else
            {
                changeView(prevView.View, prevView.Arg);
            }
        }
    }
}
