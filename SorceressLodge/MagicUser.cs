using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide {
    public class MagicUser {
        int uID;
        List<Bounty> bounty;
        string description;
        string name;
        string surname;
        List<Location> location;
        Image image;
        Dictionary<MagicType, int[]> skills;

        public List<Bounty> Bounty {
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

        public Dictionary<MagicType, int[]> Skills {
            get { return skills; }
            set { skills = value; }
        }

        public MagicUser(int uid, string name, string surname, string description, Image image, Dictionary<MagicType, int[]> skills, List<Bounty> bounty, List<Location> location) {
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
