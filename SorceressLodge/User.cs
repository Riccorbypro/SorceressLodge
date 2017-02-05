using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class User {
        int uID;
        double bounty;
        string description;
        string name;
        string surname;
        string location;
        Image image;

        public double Bounty {
            get { return bounty; }
            set { bounty = value; }
        }

        public int UID {
            get { return uID; }
            set { uID = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Surname {
            get { return surname; }
            set { surname = value; }
        }

        public string Location {
            get { return location; }
            set { location = value; }
        }

        public Image Image {
            get { return image; }
            set { image = value; }
        }

        public User(int uid, double bounty, string surname, string name, string description, string location, Image image) {
            this.bounty = bounty;
            this.description = description;
            this.location = location;
            this.name = name;
            this.surname = surname;
            this.uID = uid;
            this.image = image;
        }
    }
}
