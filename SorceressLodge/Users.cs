using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class Users {
        string userName;
        string password;

        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        public string Password {
            get { return password; }
            set { password = value; }
        }

        public Users(string username, string password) {
            this.userName = username;
            this.password = password;
        }
    }
}
