using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorceressLodge {
    class Backend {

        private List<MagicUser> users;
        private Connection conn;

        public Backend() {
            conn = new Connection();
            users = conn.ReadMagicUsers();
        }

        public DataGridView SearchUsers(Dictionary<string, object> searchTerms) {
            DataGridView dgv = new DataGridView();


            return dgv;
        }

    }
}
