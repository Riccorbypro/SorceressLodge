using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Data;

namespace SorceressLodge {
    class Connection {
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader datareader;

        public Connection() {
            string conn = @"Data Source=RICCORBYPRO-PC;Initial Catalog=SorceressLodge;Integrated Security=True";
            //@"Data Source=DESKTOP-C12M830\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True" WelterZen
            //@"Data Source=RICCORBYPRO-PC;Initial Catalog=SorceressLodge;Integrated Security=True" Riccorbypro
            sqlconn = new SqlConnection(conn);
        }

        public List<MagicUser> ReadMagicUsers() {
            List<MagicUser> MagicUserlst = new List<MagicUser>();
            List<MagicType> magictypes = ReadTypes();
            List<object[]> osLocation = ReadData("Location");
            List<Location> location = new List<Location>();
            foreach (object[] oa in osLocation) {
                location.Add(new Location((int)oa[0], (int)oa[1], (string)oa[2], (DateTime)oa[3]));
            }

            List<object[]> osSkills = ReadData("UserSkills");
            Dictionary<int[], MagicType> skills = new Dictionary<int[], MagicType>();
            foreach (object[] oa in osSkills) {
                //temp[0] ID
                //temp[1] USER
                //temp[2] SKILLLVL
                int[] temp = { (int)oa[0], (int)oa[1], (int)oa[3] };
                MagicType t = null;
                foreach (MagicType type in magictypes) {
                    if (type.ID == (int)oa[2]) {
                        t = type;
                    }
                }
                skills.Add(temp, t);
            }

            List<object[]> osBounty = ReadData("Bounty");
            List<Bounty> bounty = new List<Bounty>();
            foreach (object[] oa in osBounty) {
                bounty.Add(new Bounty((int)oa[0], (int)oa[1], (double)oa[2]));
            }

            List<object[]> osMagicUser = ReadData("MagicUsers");
            foreach (object[] oa in osMagicUser) {
                int uidMU = 0;
                List<Bounty> bountyMU = new List<Bounty>();
                string surnameMU = null;
                string nameMU = null;
                string descriptionMU = null;
                List<Location> locationMU = new List<Location>();
                Image imageMU = null;
                Dictionary<MagicType, int[]> skillsMU = new Dictionary<MagicType, int[]>();

                uidMU = (int)oa[0];
                nameMU = (string)oa[1];
                surnameMU = (string)oa[2];
                descriptionMU = (string)oa[3];
                try {
                    byte[] imgtmp = (byte[])oa[4];
                    using (MemoryStream ms = new MemoryStream(imgtmp)) {
                        imageMU = Image.FromStream(ms);
                    }
                } catch (Exception) {
                }
                foreach (Location l in location) {
                    if (l.UserID == uidMU) {
                        locationMU.Add(l);
                    }
                }
                foreach (Bounty b in bounty) {
                    if (b.UserID == uidMU) {
                        bountyMU.Add(b);
                    }
                }
                foreach (KeyValuePair<int[], MagicType> skill in skills) {
                    if (skill.Key[1] == uidMU) {
                        skillsMU.Add(skill.Value, new int[] { skill.Key[0], skill.Key[2] });
                    }
                }
                MagicUserlst.Add(new MagicUser(uidMU, nameMU, surnameMU, descriptionMU, imageMU, skillsMU, bountyMU, locationMU));
            }

            return MagicUserlst;
        }

        public List<Users> ReadUsers() {
            List<Users> Userslst = new List<Users>();
            sqlconn.Open();
            string Qry1 = "SELECT * from Users";
            sqlcomm = new SqlCommand(Qry1, sqlconn);
            datareader = sqlcomm.ExecuteReader();
            while (datareader.Read()) {
                string UserName = datareader.GetValue(1).ToString();
                string Password = datareader.GetValue(2).ToString();
                bool admin = false;
                int adminNum = Convert.ToInt32(datareader.GetValue(3));
                if (adminNum.Equals(1)) {
                    admin = true;
                } else if (adminNum.Equals(0)) {
                    admin = false;
                }
                Userslst.Add(new Users(UserName, Password, admin));
            }
            sqlconn.Close();
            return Userslst;
        }

        public List<MagicType> ReadTypes() {
            List<MagicType> lst = new List<MagicType>();
            sqlconn.Open();
            string Qry1 = "SELECT * from MagicTypes";
            sqlcomm = new SqlCommand(Qry1, sqlconn);
            datareader = sqlcomm.ExecuteReader();
            while (datareader.Read()) {
                lst.Add(new MagicType(datareader.GetInt32(0), datareader.GetString(1), datareader.GetBoolean(2)));
            }
            sqlconn.Close();
            return lst;
        }

        public List<object[]> ReadData(string tblName) {
            List<object[]> list = new List<object[]>();
            sqlconn.Open();
            string Qry1 = "SELECT * FROM " + tblName;
            sqlcomm = new SqlCommand(Qry1, sqlconn);
            datareader = sqlcomm.ExecuteReader();
            while (datareader.Read()) {
                object[] os = new object[datareader.FieldCount];
                for (int i = 0; i < datareader.FieldCount; i++) {
                    os[i] = datareader.GetValue(i);
                }
                list.Add(os);
            }
            sqlconn.Close();
            return list;
        }

        public bool Delete(int id) {
            try {
                sqlconn.Open();
                sqlcomm = new SqlCommand("Procedure_Delete", sqlconn);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.AddWithValue("@userid", id);
                sqlcomm.ExecuteNonQuery();
                ReadMagicUsers();
                return true;
            } catch (Exception) {
                return false;
            } finally {
                sqlconn.Close();
            }
        }
    }
}
