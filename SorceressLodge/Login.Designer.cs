﻿namespace ServerSide {
    partial class Login {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.AdminPictureBox = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.autoStartChk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.AdminPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(122, 126);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(122, 152);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(150, 20);
            this.txtUserPassword.TabIndex = 1;
            this.txtUserPassword.UseSystemPasswordChar = true;
            this.txtUserPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Window;
            this.btnLogin.Location = new System.Drawing.Point(197, 178);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // AdminPictureBox
            // 
            this.AdminPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.AdminPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AdminPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AdminPictureBox.Image")));
            this.AdminPictureBox.Location = new System.Drawing.Point(5, 7);
            this.AdminPictureBox.Name = "AdminPictureBox";
            this.AdminPictureBox.Size = new System.Drawing.Size(267, 119);
            this.AdminPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AdminPictureBox.TabIndex = 3;
            this.AdminPictureBox.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.SystemColors.Window;
            this.lblUserName.Location = new System.Drawing.Point(10, 127);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(114, 18);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.SystemColors.Window;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(10, 153);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(114, 18);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autoStartChk
            // 
            this.autoStartChk.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.autoStartChk.Checked = true;
            this.autoStartChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoStartChk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.autoStartChk.Location = new System.Drawing.Point(0, 226);
            this.autoStartChk.Name = "autoStartChk";
            this.autoStartChk.Size = new System.Drawing.Size(284, 35);
            this.autoStartChk.TabIndex = 6;
            this.autoStartChk.Text = "Automatically Start Server";
            this.autoStartChk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.autoStartChk.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.autoStartChk);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.AdminPictureBox);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserName);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.AdminPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox AdminPictureBox;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox autoStartChk;
    }
}