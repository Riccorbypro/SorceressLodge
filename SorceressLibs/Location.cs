using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLibs {
    public class Location {
        private int id;

        public int ID {
            get { return id; }
            set { id = value; }
        }
        private int userID;

        public int UserID {
            get { return userID; }
            set { userID = value; }
        }
        private string location;

        public string LocationStr {
            get { return location; }
            set { location = value; }
        }
        private DateTime seen;

        public DateTime Seen {
            get { return seen; }
            set { seen = value; }
        }
        public Location(int id, int userID, string location, DateTime seen) {
            this.id = id;
            this.userID = userID;
            this.location = location;
            this.seen = seen;
        }
    }
}
