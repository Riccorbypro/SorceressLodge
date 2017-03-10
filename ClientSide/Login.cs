
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SorceressLibs;
using SorceressLibs.Properties;

namespace ClientSide {
    public partial class Login : Form {

        private KonamiCode code = new KonamiCode();
        private Connection conn;

        public Login(IPAddress ip, Socket s) {
            InitializeComponent();
            conn = new ClientSide.Connection(ip, s);
            AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            try {
                Users loginAttempt = new Users(txtUserName.Text, txtUserPassword.Text, false);
                Users result = (Users)conn.Comm(loginAttempt);
                if (result != null) {
                    if (result.UserName.Equals("882246467913") && result.Password.Equals("882246467913")) {
                        throw new LoginException("Username or Password Incorrect!");
                    } else if (result.IsAdmin) {
                        Hide();
                        conn.LoggedIn = true;
                        new AdminHome(conn).Show();
                    } else {
                        Hide();
                        conn.LoggedIn = true;
                        new UserHome(conn).Show();
                    }
                }
            } catch (LoginException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e) {
            Environment.Exit(0);
        }

        private void Login_KeyUp(object sender, KeyEventArgs e) {
            if (code.IsCompletedBy(e.KeyCode)) {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.KCUnlock);
                player.Load();
                player.Play();
                MessageBox.Show("My life is like a video game,\nTrying hard to beat the stage.\nAll while I am still collecting coins.");
            }
        }
    }
}
