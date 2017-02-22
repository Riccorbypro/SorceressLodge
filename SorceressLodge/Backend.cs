using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorceressLodge {
    public class Backend {

        private List<MagicUser> users;
        private Connection conn;

        enum Skill {
            None = 0, Novice, Adept, Master
        }

        public Backend() {
            conn = new Connection();
            users = conn.ReadMagicUsers();
        }

        public DataTable SearchUsers(Dictionary<string, object> searchTerms) {
            DataTable table = new DataTable("magicusers");

            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Skill Level");
            table.Columns.Add("Last Location");

            foreach (MagicUser user in users) {
                bool pass = true;
                foreach (KeyValuePair<string, object> searchTerm in searchTerms) {
                    if (searchTerm.Key.Equals("Name")) {
                        string val = (string)searchTerm.Value;
                        if (!(user.Name + " " + user.Surname).Contains(val)) {
                            pass = false;
                            break;
                        }
                    } else if (searchTerm.Key.Equals("Bounty")) {
                        bool bPass = false;
                        //[0] MIN
                        //[1] MAX
                        double[] required = (double[])searchTerm.Value;
                        foreach (Bounty b in user.Bounty) {
                            double bounty = b.BountyAmount;
                            if (bounty >= required[0] && bounty <= required[1]) {
                                bPass = true;
                                break;
                            }
                        }
                        if (!bPass) {
                            pass = false;
                        }
                    } else if (searchTerm.Key.Equals("HasSkill")) {
                        List<MagicType> required = (List<MagicType>)searchTerm.Value;
                        foreach (MagicType type in required) {
                            if (!user.Skills.Keys.Contains(type)) {
                                pass = false;
                                break;
                            }
                        }
                    } else if (searchTerm.Key.Equals("NotSkill")) {
                        List<MagicType> required = (List<MagicType>)searchTerm.Value;
                        foreach (MagicType type in required) {
                            if (user.Skills.Keys.Contains(type)) {
                                pass = false;
                                break;
                            }
                        }
                    } else if (searchTerm.Key.Equals("HasSkillLVL")) {
                        Dictionary<MagicType, int> required = (Dictionary<MagicType, int>)searchTerm.Value;
                        foreach (KeyValuePair<MagicType, int> type in required) {
                            if (!user.Skills.Contains(type)) {
                                pass = false;
                                break;
                            }
                        }
                    } else if (searchTerm.Key.Equals("Location")) {
                        string val = (string)searchTerm.Value;
                        bool lCont = false;
                        foreach (Location l in user.Location) {
                            if (l.LocationStr.Contains(val)) {
                                lCont = true;
                                break;
                            }
                        }
                        if (!lCont) {
                            pass = false;
                        }
                    }
                }
                if (pass) {
                    table.Rows.Add(user.UID, user.Name + " " + user.Surname, ParseSkill(user), LastLocation(user));
                }
            }

            return table;
        }

        private string LastLocation(MagicUser user) {
            Location temp = new Location(0, 0, "", new DateTime(1, 1, 1));

            foreach (Location location in user.Location) {
                if (location.Seen.CompareTo(temp.Seen) > 0) {
                    temp = location;
                }
            }

            return temp.LocationStr;
        }

        private string ParseSkill(MagicUser user) {
            double skillAvg = 0;
            int total = 0;
            foreach (KeyValuePair<MagicType, int> skill in user.Skills) {
                total += skill.Value;
            }
            if (user.Skills.Count > 0) {
                skillAvg = total / user.Skills.Count;
                int skillLvl = (int)Math.Round(skillAvg, MidpointRounding.AwayFromZero);
                Skill skill = (Skill)skillLvl;
                switch (skill) {
                    case Skill.None:
                        return "None";
                    case Skill.Novice:
                        return "Novice";
                    case Skill.Adept:
                        return "Adept";
                    case Skill.Master:
                        return "Master";
                    default:
                        return "Skill Level Unknown";
                }
            }
            return "Skill Level Unknown";
        }

        public List<string> getNames() {
            List<string> names = new List<string>();

            foreach (MagicUser user in users) {
                names.Add(user.Name + " " + user.Surname);
            }

            return names;
        }

        public MagicUser getUser(int id) {
            foreach (MagicUser user in users) {
                if (user.UID==id) {
                    return user
                }
            }
            return null;
        }
    }
}
