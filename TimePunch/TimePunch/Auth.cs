using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePunch
{
    public class Auth
    {

        public bool isLoggedIn { get; private set; }
        public TimePunchDatabase.User User { get; private set; }

        public Auth(string username, string password)
        {
            Authenticate(username, password);
        }

        public Auth()
        {

        }

        public bool Authenticate(string username, string password)
        {
            //find user in database
            TimePunchDatabase.TimePunchEntities dbcontext = new TimePunchDatabase.TimePunchEntities();

            var findUser = (from u in dbcontext.Users
                           where u.Username == username
                           select u).ToArray();

            dbcontext.Dispose();

            if(findUser.Length > 0)
            {

                TimePunchDatabase.User foundUser = findUser[0];
                PasswordHash ph = new PasswordHash(Convert.FromBase64String(foundUser.Password));
                if (ph.verify(password))
                {
                    this.User = foundUser;
                    this.isLoggedIn = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void Logout()
        {
            this.User = null;
            this.isLoggedIn = false;
        }





    }
}
