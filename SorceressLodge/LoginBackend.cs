using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class LoginBackend {

        public static bool Login(string username, string password) {
            Connection conn = new Connection();
            List<Users> userlst = conn.ReadUsers();
            foreach (Users item in userlst) {
                if ((item.UserName.Equals(username)) && (item.Password.Equals(password))) {
                    if (item.IsAdmin == true) {
                        new AdminHome().Show();
                        return true;
                    } else {
                        new UserHome().Show();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
