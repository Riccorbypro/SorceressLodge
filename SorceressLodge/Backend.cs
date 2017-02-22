using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorceressLodge {
    class Backend {

        private List<MagicUser> users;
        private Connection conn;

        public Backend() {
            conn = new Connection();
            users = conn.ReadMagicUsers();
        }

        public DataTable SearchUsers(Dictionary<string, object> searchTerms) {
            DataTable table = new DataTable("magicusers");

            table.Columns.Add("Name");
            table.Columns.Add("Surname");
            table.Columns.Add("Skill Level");
            table.Columns.Add("Last Location");

            foreach (MagicUser user in users) {
                bool pass = true;
                foreach (KeyValuePair<string, object> searchTerm in searchTerms) {
                    if (searchTerm.Key.Equals("Name")) {
                        string val = (string)searchTerm.Value;
                        if (!user.Name.Equals(val)) {
                            pass = false;
                            break;
                        }
                    } else if (searchTerm.Key.Equals("Surname")) {
                        string val = (string)searchTerm.Value;
                        if (!user.Surname.Equals(val)) {
                            pass = false;
                            break;
                        }
                    } else if (searchTerm.Key.Equals("Bounty")) {
                        bool bPass = false;
                        //[0] MIN
                        //[1] MAX
                        double[] required = (double[])searchTerm.Value;
                        foreach (double bounty in user.Bounty) {
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
                            if (l.LocationStr.Contains(val) {
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
                    table.Rows.Add(user.Name, user.Surname, ParseSkill(user), LastLocation(user));
                }
            }

            return table;
        }

        private string LastLocation(MagicUser user) {
            throw new NotImplementedException();
        }

        private string ParseSkill(MagicUser user) {
            throw new NotImplementedException();
        }
    }
}
