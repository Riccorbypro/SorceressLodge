using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide {
    public partial class AdvancedSearch : Form {

        private Backend b;

        public AdvancedSearch(Backend be) {
            b = be;
            InitializeComponent();
        }

        private void btnAdvancedSearch_Click(object sender, EventArgs e) {

        }
    }
}
