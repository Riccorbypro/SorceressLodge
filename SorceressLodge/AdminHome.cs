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
        SqlConnection sqlconn;
        DataTable table;
        DataSet dataset;
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

            }
        }

        private void Deletebtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Magic User", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                int uID = Convert.ToInt32(usersTable.SelectedCells[0].Value);
                string conn = @"Data Source=DESKTOP-C12M830\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True";
                //@"Data Source=DESKTOP-C12M830\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True" WelterZen
                //@"Data Source=DESKTOP-103SE6A\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True" Riccorbypro

                sqlconn = new SqlConnection(conn);
                sqlconn.Open();
                SqlCommand sqlcom = new SqlCommand("Procedure_Delete", sqlconn);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.AddWithValue("@userid", uID);
                sqlcom.ExecuteNonQuery();
                sqlconn.Close();
                MessageBox.Show("Magic user deleted", "Deleted");
                setTable();
            }
        }

        private void AdminHome_Load(object sender, EventArgs e) {
            Dictionary<int, string> item = new Dictionary<int, string>();
            item.Add(1, "Novice");
            item.Add(2, "Adept");
            item.Add(3, "Master");
            cmbLevelA.DataSource = new BindingSource(item,null);
            cmbLevelA.DisplayMember = "Value";
            cmbLevelA.ValueMember = "Key";
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
        }
    }
}
