
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SorceressLibs;

namespace ClientSide {
    public partial class Login : Form {

        private KonamiCode code = new KonamiCode();

        public Login() {
            InitializeComponent();
            //AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            //try {
            //    if (!LoginBackend.Login(txtUserName.Text, txtUserPassword.Text)) {
            //        throw new LoginException("Username or Password Incorrect!");
            //    } else {
            //        this.Hide();
            //    }
            //} catch (LoginException ex) {
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void Login_KeyUp(object sender, KeyEventArgs e) {
            //if (code.IsCompletedBy(e.KeyCode)) {
            //    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.KCUnlock);
            //    player.Load();
            //    player.Play();
            //    MessageBox.Show("My life is like a video game,\nTrying hard to beat the stage.\nAll while I am still collecting coins.");
            //}
        }
    }
}
