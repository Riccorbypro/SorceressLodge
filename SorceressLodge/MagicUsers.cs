using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorceressLodge {
    class MagicUsers {
        int uID;
        double[] bounty;
        string description;
        string name;
        string surname;
        List<Location> location;
        Image image;
        Dictionary<MagicType, int> skills;

        public double[] Bounty {
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

        public List<Location> Location {
            get { return location; }
            set { location = value; }
        }

        public Image Image {
            get { return image; }
            set { image = value; }
        }

        public Dictionary<MagicType, int> Skills {
            get { return skills; }
            set { skills = value; }
        }

        public MagicUsers(int uid, double[] bounty, string surname, string name, string description, List<Location> location, Image image, Dictionary<MagicType, int> skills) {
            this.bounty = bounty;
            this.description = description;
            this.location = location;
            this.name = name;
            this.surname = surname;
            this.uID = uid;
            this.image = image;
            this.skills = skills;
        }
    }
}
