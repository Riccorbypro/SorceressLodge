using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorceressLodge {
    public partial class UserHome : Form {

        
        private Backend b;

        public UserHome() {
            b = new Backend();
            InitializeComponent();
            nameSelectCmb.DataSource = b.getNames();
            setTable();
            nameSelectCmb.Text = "";
        }

        private void setTable() {
            DataTable table = null;
            if (nameSelectCmb.Text.Equals("")) {
                table = b.SearchUsers(new Dictionary<string, object>());
            } else {
                table = b.SearchUsers(new Dictionary<string, object>() { { "Name", nameSelectCmb.Text } });
            }
            usersTable.DataSource = table;
            usersTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersTable.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            setTable();
        }

        private void UserHome_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void btnAdvancS_Click(object sender, EventArgs e) {
            AdvancedSearch ads = new AdvancedSearch(b);
            ads.Show();
        }

        private void usersTable_MouseDoubleClick(object sender, MouseEventArgs e) {
            int id = Convert.ToInt32(usersTable.SelectedRows[0].Cells[0].Value);
            MagicUser user;
            if ((user = b.getUser(id)) != null) {
                Update u = new Update(user, b);
                u.Show();
            }
        }
        
        private void tabAdd_Click(object sender, EventArgs e) {

        }

        private void txtNameA_TextChanged(object sender, EventArgs e) {

        }
    }
}
