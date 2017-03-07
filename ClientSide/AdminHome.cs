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
using SorceressLibs;


namespace ClientSide {
    public partial class AdminHome : Form {

        //private DataTable table;
        //private Backend b;
        //List<Bounty> listBlounty = new List<Bounty>();
        //List<Location> listLocation = new List<Location>();
        //Dictionary<MagicType, int[]> dicSkill = new Dictionary<MagicType, int[]>();
        public AdminHome() {
            //b = new Backend();
            InitializeComponent();
            //nameSelectCmb.DataSource = b.getNames();
            //setTable();
            //nameSelectCmb.Text = "";
        }

        private void AdminHome_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void setTable() {
            //table = null;
            //if (nameSelectCmb.Text.Equals("")) {
            //    table = b.SearchUsers(new Dictionary<string, object>());
            //} else {
            //    table = b.SearchUsers(new Dictionary<string, object>() { { "Name", nameSelectCmb.Text } });
            //}
            //usersTable.DataSource = table;
            //usersTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //usersTable.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            //setTable();
        }

        private void btnAdvancS_Click(object sender, EventArgs e) {
            //AdvancedSearch ads = new AdvancedSearch(b);
            //ads.Show();
        }

        private void usersTable_MouseDoubleClick(object sender, MouseEventArgs e) {
            //int id = (int)usersTable.SelectedRows[0].Cells[0].Value;
            //MagicUser user;
            //if ((user = b.getUser(id)) != null) {
            //    Update u = new Update(user, b);
            //    u.Show();
            //}
        }

        private void Deletebtn_Click(object sender, EventArgs e) {
            //string MagicUserName = "Delete " + usersTable.SelectedCells[1].Value.ToString();
            //if (MessageBox.Show("Are you sure you want to delete this user?", MagicUserName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
            //    int uID = Convert.ToInt32(usersTable.SelectedCells[0].Value);
            //    if (b.DeleteUser(uID)) {
            //        MessageBox.Show("Magic user deleted", "Deleted");
            //        b = new Backend();
            //        nameSelectCmb.DataSource = b.getNames();
            //        setTable();
            //    } else {
            //        MessageBox.Show("Deletion Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void AdminHome_Load(object sender, EventArgs e) {
            //Dictionary<int, string> SkillItem = new Dictionary<int, string>();
            //SkillItem.Add(1, "Novice");
            //SkillItem.Add(2, "Adept");
            //SkillItem.Add(3, "Master");
            //cmbLevelA.DataSource = new BindingSource(SkillItem, null);
            //cmbLevelA.DisplayMember = "Value";
            //cmbLevelA.ValueMember = "Key";

            //List<MagicType> types = b.getTypes();
            //cmbMagicA.DataSource = types;
        }

        private void btnAddAll_Click(object sender, EventArgs e) {
            //try {
            //    string fname = txtNameA.Text;
            //    string sname = txtSurnameA.Text;
            //    string desc = txtDescription.Text;
            //    Image image = pictureBox1.Image;

            //    MagicUser User = new MagicUser(0, fname, sname, desc, image, dicSkill, listBlounty, listLocation);
            //    b.InsertUser(User);
            //    string names = "Succesfully added " + fname + " " + sname;
            //    MessageBox.Show(names, "Added to database");
            //} catch (Exception) {
            //    MessageBox.Show("Incorrect values entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} finally {
            //    txtBountyA.Clear();
            //    txtDescription.Clear();
            //    txtLocationA.Clear();
            //    txtNameA.Clear();
            //    txtSurnameA.Clear();
            //    lstbBountyAdd.Items.Clear();
            //    lstbLocationAdd.Items.Clear();
            //    lstbMagicAdd.Items.Clear();
            //}
        }

        private void usersTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //int id = Convert.ToInt32(usersTable.SelectedRows[0].Cells[0].Value);
            //MagicUser user;
            //if ((user = b.getUser(id)) != null) {
            //    Update u = new Update(user, b);
            //    u.Show();
            //}
        }

        private void btnLocationAdd_Click(object sender, EventArgs e) {
            //try {
            //    listLocation.Add(new SorceressLodge.Location(0, 0, txtLocationA.Text, dtpLocationA.Value));
            //    lstbLocationAdd.Items.Add(txtLocationA.Text + " " + dtpLocationA.Value.ToString());
            //    txtLocationA.Clear();
            //    dtpLocationA.ResetText();
            //} catch (Exception) {
            //    MessageBox.Show("Incorrect values entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnAddMagic_Click(object sender, EventArgs e) {
            //try {
            //    int[] prof = { 0, int.Parse(cmbLevelA.SelectedValue.ToString()), 0 };
            //    dicSkill.Add((MagicType)cmbMagicA.SelectedValue, prof);
            //    lstbMagicAdd.Items.Add(cmbMagicA.SelectedValue + " (" + cmbLevelA.SelectedValue + ")");
            //} catch (Exception) {
            //    MessageBox.Show("Incorrect values entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnAddBounty_Click(object sender, EventArgs e) {
            //try {
            //    listBlounty.Add(new Bounty(0, 0, double.Parse(txtBountyA.Text)));
            //    lstbBountyAdd.Items.Add("R" + txtBountyA.Text);
            //    txtBountyA.Clear();
            //} catch (Exception) {
            //    MessageBox.Show("Incorrect values entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
