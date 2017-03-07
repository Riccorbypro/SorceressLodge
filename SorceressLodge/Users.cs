using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide {
    class Users {
        string userName;
        string password;
        bool isAdmin;

        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        public string Password {
            get { return password; }
            set { password = value; }
        }

        public bool IsAdmin {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public Users(string username, string password, bool isAdmin) {
            this.userName = username;
            this.password = password;
            this.isAdmin = isAdmin;
        }
    }
}
