using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    public class Bounty {
        private int bountyID;

        public int BountyID {
            get { return bountyID; }
            set { bountyID = value; }
        }
        private int userID;

        public int UserID {
            get { return userID; }
            set { userID = value; }
        }
        private double bounty;

        public double BountyAmount {
            get { return bounty; }
            set { bounty = value; }
        }
        public Bounty(int bountyID, int userID, double bounty) {
            this.bountyID = bountyID;
            this.userID = userID;
            this.bounty = bounty;
        }
    }
}
