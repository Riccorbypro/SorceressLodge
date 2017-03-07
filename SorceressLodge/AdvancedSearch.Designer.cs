namespace ServerSide {
    partial class AdvancedSearch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSearch));
            this.cmbNameAS = new System.Windows.Forms.ComboBox();
            this.txtBountyMin = new System.Windows.Forms.TextBox();
            this.txtBountyMax = new System.Windows.Forms.TextBox();
            this.lblMinus = new System.Windows.Forms.Label();
            this.cmbLocationAS = new System.Windows.Forms.ComboBox();
            this.dgvAdvancedSearch = new System.Windows.Forms.DataGridView();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.btnAdvancedSearch = new System.Windows.Forms.Button();
            this.lblNameAS = new System.Windows.Forms.Label();
            this.lblBountyAS = new System.Windows.Forms.Label();
            this.lblMagicTypeAS = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.clbMagicTypes = new System.Windows.Forms.CheckedListBox();
            this.lblLocationAS = new System.Windows.Forms.Label();
            this.btnBackAS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvancedSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNameAS
            // 
            this.cmbNameAS.FormattingEnabled = true;
            this.cmbNameAS.Location = new System.Drawing.Point(12, 59);
            this.cmbNameAS.Name = "cmbNameAS";
            this.cmbNameAS.Size = new System.Drawing.Size(224, 21);
            this.cmbNameAS.TabIndex = 0;
            // 
            // txtBountyMin
            // 
            this.txtBountyMin.Location = new System.Drawing.Point(12, 118);
            this.txtBountyMin.Name = "txtBountyMin";
            this.txtBountyMin.Size = new System.Drawing.Size(100, 20);
            this.txtBountyMin.TabIndex = 1;
            // 
            // txtBountyMax
            // 
            this.txtBountyMax.Location = new System.Drawing.Point(136, 118);
            this.txtBountyMax.Name = "txtBountyMax";
            this.txtBountyMax.Size = new System.Drawing.Size(100, 20);
            this.txtBountyMax.TabIndex = 2;
            // 
            // lblMinus
            // 
            this.lblMinus.BackColor = System.Drawing.SystemColors.Window;
            this.lblMinus.Location = new System.Drawing.Point(101, 119);
            this.lblMinus.Name = "lblMinus";
            this.lblMinus.Size = new System.Drawing.Size(43, 18);
            this.lblMinus.TabIndex = 3;
            this.lblMinus.Text = "-";
            this.lblMinus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLocationAS
            // 
            this.cmbLocationAS.FormattingEnabled = true;
            this.cmbLocationAS.Location = new System.Drawing.Point(12, 168);
            this.cmbLocationAS.Name = "cmbLocationAS";
            this.cmbLocationAS.Size = new System.Drawing.Size(224, 21);
            this.cmbLocationAS.TabIndex = 6;
            // 
            // dgvAdvancedSearch
            // 
            this.dgvAdvancedSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdvancedSearch.Location = new System.Drawing.Point(12, 255);
            this.dgvAdvancedSearch.Name = "dgvAdvancedSearch";
            this.dgvAdvancedSearch.Size = new System.Drawing.Size(502, 206);
            this.dgvAdvancedSearch.TabIndex = 7;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(11, 226);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(351, 21);
            this.comboBox4.TabIndex = 8;
            // 
            // btnAdvancedSearch
            // 
            this.btnAdvancedSearch.Location = new System.Drawing.Point(368, 226);
            this.btnAdvancedSearch.Name = "btnAdvancedSearch";
            this.btnAdvancedSearch.Size = new System.Drawing.Size(146, 23);
            this.btnAdvancedSearch.TabIndex = 9;
            this.btnAdvancedSearch.Text = "Search";
            this.btnAdvancedSearch.UseVisualStyleBackColor = true;
            this.btnAdvancedSearch.Click += new System.EventHandler(this.btnAdvancedSearch_Click);
            // 
            // lblNameAS
            // 
            this.lblNameAS.BackColor = System.Drawing.SystemColors.Window;
            this.lblNameAS.Location = new System.Drawing.Point(13, 42);
            this.lblNameAS.Name = "lblNameAS";
            this.lblNameAS.Size = new System.Drawing.Size(131, 18);
            this.lblNameAS.TabIndex = 10;
            this.lblNameAS.Text = "Name and Surname";
            this.lblNameAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBountyAS
            // 
            this.lblBountyAS.BackColor = System.Drawing.SystemColors.Window;
            this.lblBountyAS.Location = new System.Drawing.Point(13, 101);
            this.lblBountyAS.Name = "lblBountyAS";
            this.lblBountyAS.Size = new System.Drawing.Size(100, 18);
            this.lblBountyAS.TabIndex = 11;
            this.lblBountyAS.Text = "Bounty";
            this.lblBountyAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMagicTypeAS
            // 
            this.lblMagicTypeAS.BackColor = System.Drawing.SystemColors.Window;
            this.lblMagicTypeAS.Location = new System.Drawing.Point(369, 41);
            this.lblMagicTypeAS.Name = "lblMagicTypeAS";
            this.lblMagicTypeAS.Size = new System.Drawing.Size(69, 18);
            this.lblMagicTypeAS.TabIndex = 12;
            this.lblMagicTypeAS.Text = "Magic Type";
            this.lblMagicTypeAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.SystemColors.Window;
            this.lblDesc.Location = new System.Drawing.Point(12, 209);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 18);
            this.lblDesc.TabIndex = 15;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clbMagicTypes
            // 
            this.clbMagicTypes.FormattingEnabled = true;
            this.clbMagicTypes.Location = new System.Drawing.Point(368, 59);
            this.clbMagicTypes.Name = "clbMagicTypes";
            this.clbMagicTypes.Size = new System.Drawing.Size(146, 139);
            this.clbMagicTypes.TabIndex = 18;
            // 
            // lblLocationAS
            // 
            this.lblLocationAS.BackColor = System.Drawing.SystemColors.Window;
            this.lblLocationAS.Location = new System.Drawing.Point(13, 151);
            this.lblLocationAS.Name = "lblLocationAS";
            this.lblLocationAS.Size = new System.Drawing.Size(100, 18);
            this.lblLocationAS.TabIndex = 19;
            this.lblLocationAS.Text = "Location";
            this.lblLocationAS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackAS
            // 
            this.btnBackAS.Location = new System.Drawing.Point(368, 462);
            this.btnBackAS.Name = "btnBackAS";
            this.btnBackAS.Size = new System.Drawing.Size(146, 23);
            this.btnBackAS.TabIndex = 20;
            this.btnBackAS.Text = "Back";
            this.btnBackAS.UseVisualStyleBackColor = true;
            // 
            // AdvancedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 497);
            this.Controls.Add(this.btnBackAS);
            this.Controls.Add(this.lblLocationAS);
            this.Controls.Add(this.clbMagicTypes);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblMagicTypeAS);
            this.Controls.Add(this.lblBountyAS);
            this.Controls.Add(this.lblNameAS);
            this.Controls.Add(this.btnAdvancedSearch);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.dgvAdvancedSearch);
            this.Controls.Add(this.cmbLocationAS);
            this.Controls.Add(this.lblMinus);
            this.Controls.Add(this.txtBountyMax);
            this.Controls.Add(this.txtBountyMin);
            this.Controls.Add(this.cmbNameAS);
            this.Name = "AdvancedSearch";
            this.Text = "AdvancedSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdvancedSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNameAS;
        private System.Windows.Forms.TextBox txtBountyMin;
        private System.Windows.Forms.TextBox txtBountyMax;
        private System.Windows.Forms.Label lblMinus;
        private System.Windows.Forms.ComboBox cmbLocationAS;
        private System.Windows.Forms.DataGridView dgvAdvancedSearch;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button btnAdvancedSearch;
        private System.Windows.Forms.Label lblNameAS;
        private System.Windows.Forms.Label lblBountyAS;
        private System.Windows.Forms.Label lblMagicTypeAS;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.CheckedListBox clbMagicTypes;
        private System.Windows.Forms.Label lblLocationAS;
        private System.Windows.Forms.Button btnBackAS;
    }
}