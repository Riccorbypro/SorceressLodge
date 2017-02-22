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
        private Backend b;

        public Update(MagicUser user, Backend b) {
            InitializeComponent();
            this.user = user;
            this.b = b;
            setFields();
        }

        private void setFields() {
            if (user.Image != null) {
                pbPictureU.Image = user.Image;
            }
            txtNameU.Text = user.Name;
            txtSurnameU.Text = user.Surname;
            List<string> locationLst = new List<string>();
            foreach (Location l in user.Location) {
                locationLst.Add(l.Seen.ToShortDateString() + " " + l.Seen.ToShortTimeString() + ": " + l.LocationStr);
            }
            lstbLocationUpdate.DataSource = locationLst;
            List<string> bountyLst = new List<string>();
            foreach (Bounty l in user.Bounty) {
                bountyLst.Add(l.BountyAmount.ToString("c"));
            }
            lstbBountyUpdate.DataSource = bountyLst;
            List<string> magicLst = new List<string>();
            foreach (KeyValuePair<MagicType, int> skill in user.Skills) {
                magicLst.Add(skill.Key.Type + " (" + b.getSkillLevel(skill.Value) + ")");
            }
            lstbMagicUpdate.DataSource = magicLst;
        }
    }
}
