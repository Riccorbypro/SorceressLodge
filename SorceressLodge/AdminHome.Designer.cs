namespace SorceressLodge {
    partial class AdminHome {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHome));
            this.tabcontrols = new System.Windows.Forms.TabControl();
            this.tabView = new System.Windows.Forms.TabPage();
            this.btnAdvancS = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.nameSelectCmb = new System.Windows.Forms.ComboBox();
            this.usersTable = new System.Windows.Forms.DataGridView();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lstbLocationAdd = new System.Windows.Forms.ListBox();
            this.dtpLocationA = new System.Windows.Forms.DateTimePicker();
            this.lblDescA = new System.Windows.Forms.Label();
            this.lblBountyA = new System.Windows.Forms.Label();
            this.lblMagicLevelA = new System.Windows.Forms.Label();
            this.lblLocationA = new System.Windows.Forms.Label();
            this.lblMagicA = new System.Windows.Forms.Label();
            this.lblNameA = new System.Windows.Forms.Label();
            this.btnAddBounty = new System.Windows.Forms.Button();
            this.lstbBountyAdd = new System.Windows.Forms.ListBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtLocationA = new System.Windows.Forms.TextBox();
            this.txtBountyA = new System.Windows.Forms.TextBox();
            this.btnAddMagic = new System.Windows.Forms.Button();
            this.cmbLevelA = new System.Windows.Forms.ComboBox();
            this.cmbMagicA = new System.Windows.Forms.ComboBox();
            this.lstbMagicAdd = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblUserNameA = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserNameA = new System.Windows.Forms.TextBox();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.txtNameA = new System.Windows.Forms.TextBox();
            this.txtSurnameA = new System.Windows.Forms.TextBox();
            this.tabcontrols.SuspendLayout();
            this.tabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).BeginInit();
            this.tabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabcontrols
            // 
            this.tabcontrols.Controls.Add(this.tabView);
            this.tabcontrols.Controls.Add(this.tabAdd);
            this.tabcontrols.Controls.Add(this.tabPage1);
            this.tabcontrols.Location = new System.Drawing.Point(12, 4);
            this.tabcontrols.Name = "tabcontrols";
            this.tabcontrols.SelectedIndex = 0;
            this.tabcontrols.Size = new System.Drawing.Size(490, 405);
            this.tabcontrols.TabIndex = 0;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.Deletebtn);
            this.tabView.Controls.Add(this.btnAdvancS);
            this.tabView.Controls.Add(this.btnSearch);
            this.tabView.Controls.Add(this.nameSelectCmb);
            this.tabView.Controls.Add(this.usersTable);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(482, 379);
            this.tabView.TabIndex = 0;
            this.tabView.Text = "View Magic User";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // btnAdvancS
            // 
            this.btnAdvancS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdvancS.Location = new System.Drawing.Point(326, 24);
            this.btnAdvancS.Name = "btnAdvancS";
            this.btnAdvancS.Size = new System.Drawing.Size(140, 23);
            this.btnAdvancS.TabIndex = 3;
            this.btnAdvancS.Text = "Advanced Search";
            this.btnAdvancS.UseVisualStyleBackColor = true;
            this.btnAdvancS.Click += new System.EventHandler(this.btnAdvancS_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Location = new System.Drawing.Point(245, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // nameSelectCmb
            // 
            this.nameSelectCmb.FormattingEnabled = true;
            this.nameSelectCmb.Location = new System.Drawing.Point(19, 26);
            this.nameSelectCmb.Name = "nameSelectCmb";
            this.nameSelectCmb.Size = new System.Drawing.Size(220, 21);
            this.nameSelectCmb.TabIndex = 1;
            // 
            // usersTable
            // 
            this.usersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersTable.Location = new System.Drawing.Point(19, 53);
            this.usersTable.Name = "usersTable";
            this.usersTable.Size = new System.Drawing.Size(447, 270);
            this.usersTable.TabIndex = 0;
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.txtSurnameA);
            this.tabAdd.Controls.Add(this.txtNameA);
            this.tabAdd.Controls.Add(this.pictureBox1);
            this.tabAdd.Controls.Add(this.btnAddPicture);
            this.tabAdd.Controls.Add(this.btnAddAll);
            this.tabAdd.Controls.Add(this.lstbLocationAdd);
            this.tabAdd.Controls.Add(this.dtpLocationA);
            this.tabAdd.Controls.Add(this.lblDescA);
            this.tabAdd.Controls.Add(this.lblBountyA);
            this.tabAdd.Controls.Add(this.lblMagicLevelA);
            this.tabAdd.Controls.Add(this.lblLocationA);
            this.tabAdd.Controls.Add(this.lblMagicA);
            this.tabAdd.Controls.Add(this.lblNameA);
            this.tabAdd.Controls.Add(this.btnAddBounty);
            this.tabAdd.Controls.Add(this.lstbBountyAdd);
            this.tabAdd.Controls.Add(this.txtDescription);
            this.tabAdd.Controls.Add(this.txtLocationA);
            this.tabAdd.Controls.Add(this.txtBountyA);
            this.tabAdd.Controls.Add(this.btnAddMagic);
            this.tabAdd.Controls.Add(this.cmbLevelA);
            this.tabAdd.Controls.Add(this.cmbMagicA);
            this.tabAdd.Controls.Add(this.lstbMagicAdd);
            this.tabAdd.Location = new System.Drawing.Point(4, 22);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(482, 379);
            this.tabAdd.TabIndex = 1;
            this.tabAdd.Text = "Add Magic User";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(196, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 95);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddPicture.Location = new System.Drawing.Point(366, 300);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(101, 23);
            this.btnAddPicture.TabIndex = 20;
            this.btnAddPicture.Text = "Add Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddAll.Location = new System.Drawing.Point(367, 330);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(100, 23);
            this.btnAddAll.TabIndex = 19;
            this.btnAddAll.Text = "Add to Database";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // lstbLocationAdd
            // 
            this.lstbLocationAdd.FormattingEnabled = true;
            this.lstbLocationAdd.Location = new System.Drawing.Point(6, 177);
            this.lstbLocationAdd.Name = "lstbLocationAdd";
            this.lstbLocationAdd.Size = new System.Drawing.Size(183, 95);
            this.lstbLocationAdd.TabIndex = 18;
            // 
            // dtpLocationA
            // 
            this.dtpLocationA.Location = new System.Drawing.Point(6, 151);
            this.dtpLocationA.Name = "dtpLocationA";
            this.dtpLocationA.Size = new System.Drawing.Size(184, 20);
            this.dtpLocationA.TabIndex = 17;
            // 
            // lblDescA
            // 
            this.lblDescA.AutoSize = true;
            this.lblDescA.Location = new System.Drawing.Point(6, 286);
            this.lblDescA.Name = "lblDescA";
            this.lblDescA.Size = new System.Drawing.Size(60, 13);
            this.lblDescA.TabIndex = 16;
            this.lblDescA.Text = "Description";
            // 
            // lblBountyA
            // 
            this.lblBountyA.AutoSize = true;
            this.lblBountyA.Location = new System.Drawing.Point(427, 53);
            this.lblBountyA.Name = "lblBountyA";
            this.lblBountyA.Size = new System.Drawing.Size(40, 13);
            this.lblBountyA.TabIndex = 15;
            this.lblBountyA.Text = "Bounty";
            // 
            // lblMagicLevelA
            // 
            this.lblMagicLevelA.AutoSize = true;
            this.lblMagicLevelA.Location = new System.Drawing.Point(192, 98);
            this.lblMagicLevelA.Name = "lblMagicLevelA";
            this.lblMagicLevelA.Size = new System.Drawing.Size(55, 13);
            this.lblMagicLevelA.TabIndex = 14;
            this.lblMagicLevelA.Text = "Skill Level";
            // 
            // lblLocationA
            // 
            this.lblLocationA.AutoSize = true;
            this.lblLocationA.Location = new System.Drawing.Point(6, 109);
            this.lblLocationA.Name = "lblLocationA";
            this.lblLocationA.Size = new System.Drawing.Size(48, 13);
            this.lblLocationA.TabIndex = 13;
            this.lblLocationA.Text = "Location";
            // 
            // lblMagicA
            // 
            this.lblMagicA.AutoSize = true;
            this.lblMagicA.Location = new System.Drawing.Point(192, 54);
            this.lblMagicA.Name = "lblMagicA";
            this.lblMagicA.Size = new System.Drawing.Size(63, 13);
            this.lblMagicA.TabIndex = 12;
            this.lblMagicA.Text = "Magic Type";
            // 
            // lblNameA
            // 
            this.lblNameA.AutoSize = true;
            this.lblNameA.Location = new System.Drawing.Point(6, 55);
            this.lblNameA.Name = "lblNameA";
            this.lblNameA.Size = new System.Drawing.Size(126, 13);
            this.lblNameA.TabIndex = 11;
            this.lblNameA.Text = "User Name and Surname";
            // 
            // btnAddBounty
            // 
            this.btnAddBounty.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddBounty.Location = new System.Drawing.Point(392, 122);
            this.btnAddBounty.Name = "btnAddBounty";
            this.btnAddBounty.Size = new System.Drawing.Size(75, 23);
            this.btnAddBounty.TabIndex = 10;
            this.btnAddBounty.Text = "Add Bounty";
            this.btnAddBounty.UseVisualStyleBackColor = true;
            // 
            // lstbBountyAdd
            // 
            this.lstbBountyAdd.FormattingEnabled = true;
            this.lstbBountyAdd.Location = new System.Drawing.Point(367, 151);
            this.lstbBountyAdd.Name = "lstbBountyAdd";
            this.lstbBountyAdd.Size = new System.Drawing.Size(100, 121);
            this.lstbBountyAdd.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Location = new System.Drawing.Point(9, 302);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(181, 71);
            this.txtDescription.TabIndex = 8;
            // 
            // txtLocationA
            // 
            this.txtLocationA.Location = new System.Drawing.Point(6, 125);
            this.txtLocationA.Name = "txtLocationA";
            this.txtLocationA.Size = new System.Drawing.Size(184, 20);
            this.txtLocationA.TabIndex = 7;
            // 
            // txtBountyA
            // 
            this.txtBountyA.Location = new System.Drawing.Point(368, 70);
            this.txtBountyA.Name = "txtBountyA";
            this.txtBountyA.Size = new System.Drawing.Size(100, 20);
            this.txtBountyA.TabIndex = 6;
            // 
            // btnAddMagic
            // 
            this.btnAddMagic.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddMagic.Location = new System.Drawing.Point(286, 122);
            this.btnAddMagic.Name = "btnAddMagic";
            this.btnAddMagic.Size = new System.Drawing.Size(75, 23);
            this.btnAddMagic.TabIndex = 5;
            this.btnAddMagic.Text = "Add Magic";
            this.btnAddMagic.UseVisualStyleBackColor = true;
            // 
            // cmbLevelA
            // 
            this.cmbLevelA.FormattingEnabled = true;
            this.cmbLevelA.Location = new System.Drawing.Point(253, 95);
            this.cmbLevelA.Name = "cmbLevelA";
            this.cmbLevelA.Size = new System.Drawing.Size(108, 21);
            this.cmbLevelA.TabIndex = 4;
            // 
            // cmbMagicA
            // 
            this.cmbMagicA.FormattingEnabled = true;
            this.cmbMagicA.Location = new System.Drawing.Point(195, 70);
            this.cmbMagicA.Name = "cmbMagicA";
            this.cmbMagicA.Size = new System.Drawing.Size(166, 21);
            this.cmbMagicA.TabIndex = 3;
            // 
            // lstbMagicAdd
            // 
            this.lstbMagicAdd.FormattingEnabled = true;
            this.lstbMagicAdd.Location = new System.Drawing.Point(195, 151);
            this.lstbMagicAdd.Name = "lstbMagicAdd";
            this.lstbMagicAdd.Size = new System.Drawing.Size(166, 121);
            this.lstbMagicAdd.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblUserNameA);
            this.tabPage1.Controls.Add(this.lblUserPassword);
            this.tabPage1.Controls.Add(this.btnAddUser);
            this.tabPage1.Controls.Add(this.txtUserPassword);
            this.tabPage1.Controls.Add(this.txtUserNameA);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(482, 379);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Add User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblUserNameA
            // 
            this.lblUserNameA.AutoSize = true;
            this.lblUserNameA.Location = new System.Drawing.Point(23, 25);
            this.lblUserNameA.Name = "lblUserNameA";
            this.lblUserNameA.Size = new System.Drawing.Size(60, 13);
            this.lblUserNameA.TabIndex = 4;
            this.lblUserNameA.Text = "User Name";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(23, 80);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(53, 13);
            this.lblUserPassword.TabIndex = 3;
            this.lblUserPassword.Text = "Password";
            // 
            // btnAddUser
            // 
            this.btnAddUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddUser.Location = new System.Drawing.Point(26, 147);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(26, 96);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(250, 20);
            this.txtUserPassword.TabIndex = 1;
            // 
            // txtUserNameA
            // 
            this.txtUserNameA.Location = new System.Drawing.Point(26, 41);
            this.txtUserNameA.Name = "txtUserNameA";
            this.txtUserNameA.Size = new System.Drawing.Size(250, 20);
            this.txtUserNameA.TabIndex = 0;
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(391, 329);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(75, 23);
            this.Deletebtn.TabIndex = 4;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // txtNameA
            // 
            this.txtNameA.Location = new System.Drawing.Point(9, 71);
            this.txtNameA.Name = "txtNameA";
            this.txtNameA.Size = new System.Drawing.Size(89, 20);
            this.txtNameA.TabIndex = 22;
            // 
            // txtSurnameA
            // 
            this.txtSurnameA.Location = new System.Drawing.Point(101, 71);
            this.txtSurnameA.Name = "txtSurnameA";
            this.txtSurnameA.Size = new System.Drawing.Size(89, 20);
            this.txtSurnameA.TabIndex = 23;
            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(514, 421);
            this.Controls.Add(this.tabcontrols);
            this.Name = "AdminHome";
            this.Text = "Admin Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminHome_FormClosed);
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.tabcontrols.ResumeLayout(false);
            this.tabView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersTable)).EndInit();
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrols;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.ComboBox nameSelectCmb;
        private System.Windows.Forms.DataGridView usersTable;
        private System.Windows.Forms.ListBox lstbBountyAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLocationA;
        private System.Windows.Forms.TextBox txtBountyA;
        private System.Windows.Forms.Button btnAddMagic;
        private System.Windows.Forms.ComboBox cmbLevelA;
        private System.Windows.Forms.ComboBox cmbMagicA;
        private System.Windows.Forms.ListBox lstbMagicAdd;
        private System.Windows.Forms.Button btnAdvancS;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ListBox lstbLocationAdd;
        private System.Windows.Forms.DateTimePicker dtpLocationA;
        private System.Windows.Forms.Label lblDescA;
        private System.Windows.Forms.Label lblBountyA;
        private System.Windows.Forms.Label lblMagicLevelA;
        private System.Windows.Forms.Label lblLocationA;
        private System.Windows.Forms.Label lblMagicA;
        private System.Windows.Forms.Label lblNameA;
        private System.Windows.Forms.Button btnAddBounty;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblUserNameA;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserNameA;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.TextBox txtSurnameA;
        private System.Windows.Forms.TextBox txtNameA;
    }
}