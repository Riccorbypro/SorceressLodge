using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SorceressLibs;

namespace ServerSide {
    class LoginBackend {

        public static ServerBackend Login(string username, string password, bool autoStart) {
            Connection conn = new Connection();
            List<Users> userlst = conn.ReadUsers();
            foreach (Users item in userlst) {
                if ((item.UserName.Equals(username)) && (item.Password.Equals(password))) {
                    if (item.IsAdmin == true) {
                        ServerBackend sb = new ServerBackend(item, autoStart);
                        return sb;
                    } else {
                        return null;
                    }
                }
            }

            return null;
        }

        public static Users LoginClient(string username, string password) {
            Connection conn = new Connection();
            List<Users> userlst = conn.ReadUsers();
            foreach (Users item in userlst) {
                if ((item.UserName.Equals(username)) && (item.Password.Equals(password))) {
                    return item;
                }
            }

            return new Users("882246467913", "882246467913", false);
        }
    }
}
