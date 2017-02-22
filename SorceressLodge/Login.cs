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
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            try {
                if (!LoginBackend.Login(txtUserName.Text, txtUserPassword.Text)) {
                    throw new LoginException("Username or Password Incorrect!");
                } else {
                    this.Dispose();
                }
            } catch (LoginException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e) {

        }
    }
}
