using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace SorceressLodge {
    public partial class AdminHome : Form {

        private DataTable table;
        private Backend b;
        public AdminHome() {
            b = new Backend();
            InitializeComponent();
            nameSelectCmb.DataSource = b.getNames();
            setTable();
            nameSelectCmb.Text = "";
        }

        private void AdminHome_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void setTable() {
            table = null;
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

        private void btnAdvancS_Click(object sender, EventArgs e) {
            AdvancedSearch ads = new AdvancedSearch(b);
            ads.Show();
        }

        private void usersTable_MouseDoubleClick(object sender, MouseEventArgs e) {
            int id = (int)usersTable.SelectedRows[0].Cells[0].Value;
            MagicUser user;
            if ((user = b.getUser(id)) != null) {
                Update u = new Update(user, b);
                u.Show();
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e) {
            string MagicUserName = "Delete " + usersTable.SelectedCells[1].Value.ToString();
            if (MessageBox.Show("Are you sure you want to delete this user?", MagicUserName, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                int uID = Convert.ToInt32(usersTable.SelectedCells[0].Value);
                if (b.DeleteUser(uID)) {
                    MessageBox.Show("Magic user deleted", "Deleted");
                    setTable();
                } else {
                    MessageBox.Show("Deletion Failed");
                }
            }
        }

        private void AdminHome_Load(object sender, EventArgs e) {
            Dictionary<int, string> SkillItem = new Dictionary<int, string>();
            SkillItem.Add(1, "Novice");
            SkillItem.Add(2, "Adept");
            SkillItem.Add(3, "Master");
            cmbLevelA.DataSource = new BindingSource(SkillItem, null);
            cmbLevelA.DisplayMember = "Value";
            cmbLevelA.ValueMember = "Key";

            List<MagicType> types = b.getTypes();
            cmbMagicA.DataSource = types;
        }

        private void btnAddAll_Click(object sender, EventArgs e) {
            int userID = 0;
            int typeID = 0;
            int profc = 0;
            string fname = txtNameA.Text;
            string sname = txtSurnameA.Text;
            string desc = txtDescription.Text;
            Image image = pictureBox1.Image;
            double bounty = double.Parse(lstbBountyAdd.Text);
            string location = lstbLocationAdd.Text;
            DateTime date = Convert.ToDateTime(dtpLocationA.Text);

            //MagicUser User = new MagicUser(0,)
        }
    }
}
