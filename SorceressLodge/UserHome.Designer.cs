﻿namespace SorceressLodge {
    partial class UserHome {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserHome));
            this.tabcontrols = new System.Windows.Forms.TabControl();
            this.tabView = new System.Windows.Forms.TabPage();
            this.cmbNameS = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.txtNameA = new System.Windows.Forms.TextBox();
            this.lstbMagicAdd = new System.Windows.Forms.ListBox();
            this.cmbMagicA = new System.Windows.Forms.ComboBox();
            this.cmbLevelA = new System.Windows.Forms.ComboBox();
            this.btnAddMagic = new System.Windows.Forms.Button();
            this.txtBountyA = new System.Windows.Forms.TextBox();
            this.txtLocationA = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lstbBountyAdd = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdvancS = new System.Windows.Forms.Button();
            this.btnAddBounty = new System.Windows.Forms.Button();
            this.lblNameA = new System.Windows.Forms.Label();
            this.lblMagicA = new System.Windows.Forms.Label();
            this.lblLocationA = new System.Windows.Forms.Label();
            this.lblMagicLevelA = new System.Windows.Forms.Label();
            this.lblBountyA = new System.Windows.Forms.Label();
            this.lblDescA = new System.Windows.Forms.Label();
            this.dtpLocationA = new System.Windows.Forms.DateTimePicker();
            this.lstbLocationAdd = new System.Windows.Forms.ListBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabcontrols.SuspendLayout();
            this.tabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabcontrols
            // 
            this.tabcontrols.Controls.Add(this.tabView);
            this.tabcontrols.Controls.Add(this.tabAdd);
            this.tabcontrols.Location = new System.Drawing.Point(12, 4);
            this.tabcontrols.Name = "tabcontrols";
            this.tabcontrols.SelectedIndex = 0;
            this.tabcontrols.Size = new System.Drawing.Size(490, 405);
            this.tabcontrols.TabIndex = 0;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.btnAdvancS);
            this.tabView.Controls.Add(this.btnSearch);
            this.tabView.Controls.Add(this.cmbNameS);
            this.tabView.Controls.Add(this.dataGridView1);
            this.tabView.Location = new System.Drawing.Point(4, 22);
            this.tabView.Name = "tabView";
            this.tabView.Padding = new System.Windows.Forms.Padding(3);
            this.tabView.Size = new System.Drawing.Size(482, 379);
            this.tabView.TabIndex = 0;
            this.tabView.Text = "View";
            this.tabView.UseVisualStyleBackColor = true;
            // 
            // cmbNameS
            // 
            this.cmbNameS.FormattingEnabled = true;
            this.cmbNameS.Location = new System.Drawing.Point(19, 26);
            this.cmbNameS.Name = "cmbNameS";
            this.cmbNameS.Size = new System.Drawing.Size(220, 21);
            this.cmbNameS.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabAdd
            // 
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
            this.tabAdd.Controls.Add(this.txtNameA);
            this.tabAdd.Location = new System.Drawing.Point(4, 22);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(482, 379);
            this.tabAdd.TabIndex = 1;
            this.tabAdd.Text = "Add";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // txtNameA
            // 
            this.txtNameA.Location = new System.Drawing.Point(6, 71);
            this.txtNameA.Name = "txtNameA";
            this.txtNameA.Size = new System.Drawing.Size(184, 20);
            this.txtNameA.TabIndex = 0;
            // 
            // lstbMagicAdd
            // 
            this.lstbMagicAdd.FormattingEnabled = true;
            this.lstbMagicAdd.Location = new System.Drawing.Point(195, 151);
            this.lstbMagicAdd.Name = "lstbMagicAdd";
            this.lstbMagicAdd.Size = new System.Drawing.Size(166, 121);
            this.lstbMagicAdd.TabIndex = 2;
            // 
            // cmbMagicA
            // 
            this.cmbMagicA.FormattingEnabled = true;
            this.cmbMagicA.Location = new System.Drawing.Point(195, 70);
            this.cmbMagicA.Name = "cmbMagicA";
            this.cmbMagicA.Size = new System.Drawing.Size(166, 21);
            this.cmbMagicA.TabIndex = 3;
            // 
            // cmbLevelA
            // 
            this.cmbLevelA.FormattingEnabled = true;
            this.cmbLevelA.Location = new System.Drawing.Point(253, 95);
            this.cmbLevelA.Name = "cmbLevelA";
            this.cmbLevelA.Size = new System.Drawing.Size(108, 21);
            this.cmbLevelA.TabIndex = 4;
            // 
            // btnAddMagic
            // 
            this.btnAddMagic.Location = new System.Drawing.Point(286, 122);
            this.btnAddMagic.Name = "btnAddMagic";
            this.btnAddMagic.Size = new System.Drawing.Size(75, 23);
            this.btnAddMagic.TabIndex = 5;
            this.btnAddMagic.Text = "Add Magic";
            this.btnAddMagic.UseVisualStyleBackColor = true;
            // 
            // txtBountyA
            // 
            this.txtBountyA.Location = new System.Drawing.Point(368, 70);
            this.txtBountyA.Name = "txtBountyA";
            this.txtBountyA.Size = new System.Drawing.Size(100, 20);
            this.txtBountyA.TabIndex = 6;
            // 
            // txtLocationA
            // 
            this.txtLocationA.Location = new System.Drawing.Point(6, 125);
            this.txtLocationA.Name = "txtLocationA";
            this.txtLocationA.Size = new System.Drawing.Size(184, 20);
            this.txtLocationA.TabIndex = 7;
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
            // lstbBountyAdd
            // 
            this.lstbBountyAdd.FormattingEnabled = true;
            this.lstbBountyAdd.Location = new System.Drawing.Point(367, 151);
            this.lstbBountyAdd.Name = "lstbBountyAdd";
            this.lstbBountyAdd.Size = new System.Drawing.Size(100, 121);
            this.lstbBountyAdd.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(245, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdvancS
            // 
            this.btnAdvancS.Location = new System.Drawing.Point(326, 24);
            this.btnAdvancS.Name = "btnAdvancS";
            this.btnAdvancS.Size = new System.Drawing.Size(140, 23);
            this.btnAdvancS.TabIndex = 3;
            this.btnAdvancS.Text = "Advanced Search";
            this.btnAdvancS.UseVisualStyleBackColor = true;
            // 
            // btnAddBounty
            // 
            this.btnAddBounty.Location = new System.Drawing.Point(392, 122);
            this.btnAddBounty.Name = "btnAddBounty";
            this.btnAddBounty.Size = new System.Drawing.Size(75, 23);
            this.btnAddBounty.TabIndex = 10;
            this.btnAddBounty.Text = "Add Bounty";
            this.btnAddBounty.UseVisualStyleBackColor = true;
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
            // lblMagicA
            // 
            this.lblMagicA.AutoSize = true;
            this.lblMagicA.Location = new System.Drawing.Point(192, 54);
            this.lblMagicA.Name = "lblMagicA";
            this.lblMagicA.Size = new System.Drawing.Size(63, 13);
            this.lblMagicA.TabIndex = 12;
            this.lblMagicA.Text = "Magic Type";
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
            // lblMagicLevelA
            // 
            this.lblMagicLevelA.AutoSize = true;
            this.lblMagicLevelA.Location = new System.Drawing.Point(192, 98);
            this.lblMagicLevelA.Name = "lblMagicLevelA";
            this.lblMagicLevelA.Size = new System.Drawing.Size(55, 13);
            this.lblMagicLevelA.TabIndex = 14;
            this.lblMagicLevelA.Text = "Skill Level";
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
            // lblDescA
            // 
            this.lblDescA.AutoSize = true;
            this.lblDescA.Location = new System.Drawing.Point(6, 286);
            this.lblDescA.Name = "lblDescA";
            this.lblDescA.Size = new System.Drawing.Size(60, 13);
            this.lblDescA.TabIndex = 16;
            this.lblDescA.Text = "Description";
            // 
            // dtpLocationA
            // 
            this.dtpLocationA.Location = new System.Drawing.Point(6, 151);
            this.dtpLocationA.Name = "dtpLocationA";
            this.dtpLocationA.Size = new System.Drawing.Size(184, 20);
            this.dtpLocationA.TabIndex = 17;
            // 
            // lstbLocationAdd
            // 
            this.lstbLocationAdd.FormattingEnabled = true;
            this.lstbLocationAdd.Location = new System.Drawing.Point(6, 177);
            this.lstbLocationAdd.Name = "lstbLocationAdd";
            this.lstbLocationAdd.Size = new System.Drawing.Size(183, 95);
            this.lstbLocationAdd.TabIndex = 18;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(367, 330);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(100, 23);
            this.btnAddAll.TabIndex = 19;
            this.btnAddAll.Text = "Add to Database";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(366, 300);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(101, 23);
            this.btnAddPicture.TabIndex = 20;
            this.btnAddPicture.Text = "Add Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(196, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 95);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // UserHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(514, 421);
            this.Controls.Add(this.tabcontrols);
            this.Name = "UserHome";
            this.Text = "User Home";
            this.tabcontrols.ResumeLayout(false);
            this.tabView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabcontrols;
        private System.Windows.Forms.TabPage tabView;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.ComboBox cmbNameS;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstbBountyAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLocationA;
        private System.Windows.Forms.TextBox txtBountyA;
        private System.Windows.Forms.Button btnAddMagic;
        private System.Windows.Forms.ComboBox cmbLevelA;
        private System.Windows.Forms.ComboBox cmbMagicA;
        private System.Windows.Forms.ListBox lstbMagicAdd;
        private System.Windows.Forms.TextBox txtNameA;
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
    }
}