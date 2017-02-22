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
    public partial class Update : Form {

        private MagicUser user;

        public Update(MagicUser user) {
            InitializeComponent();
            this.user = user;
            setFields();
        }

        private void setFields() {
            if (user.Image!=null) {
                pbPictureU.Image = user.Image;
            }
            txtNameU.Text = user.Name;
            txtSurnameU.Text = user.Surname;
        }
    }
}
