using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class Backend {

        private List<MagicUser> users;
        private Connection conn;

        public Backend() {
            conn = new Connection();
            users = conn.ReadMagicUsers();
        }



    }
}
