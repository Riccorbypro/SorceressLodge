using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;

namespace SorceressLodge {
    class Connection {
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader datareader;

        public Connection() {
            string conn = @"Data Source=DESKTOP-103SE6A\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True";
            sqlconn = new SqlConnection(conn);
        }

        public List<MagicUser> ReadMagicUsers() {
            List<MagicUser> MagicUserlst = new List<MagicUser>();
            List<MagicType> types = ReadTypes();
            List<object[]> osLocation = ReadData("Location");
            List<Location> location = new List<Location>();
            foreach (object[] oa in osLocation) {
                location.Add(new Location((int)oa[0], (int)oa[1], (string)oa[2], (DateTime)oa[3]));
            }

            List<object[]> osMagicTypes = ReadData("MagicTypes");
            List<MagicType> magictype = new List<MagicType>();
            foreach (object[] oa in osMagicTypes) {
                magictype.Add(new MagicType((int)oa[0],(string)oa[1],(bool)oa[2]));
            }

            List<object[]> osBounty = ReadData("Bounty");
            List<Bounty> bounty = new List<Bounty>();
            foreach (object[] oa in osBounty) {
                bounty.Add(new Bounty((int)oa[0], (int)oa[1], (double)oa[2]));
            }

            int uidMU = 0;
            double[] bountyMU = { 0};
            string surnameMU = "";
            string nameMU = "";
            string descriptionMU = "";
            List< Location > locationMU = new List<Location>();
            Image imageMU = null;
            Dictionary< MagicType, int> skillsMU = new Dictionary<MagicType, int>();

            List<object[]> osMagicUser = ReadData("MagicUsers");
            foreach (object[] oa in osMagicUser) {
                MagicUserlst.Add(new MagicUser((int)oa[0], bountyMU, (string)oa[2], (string)oa[1],(string)oa[3],locationMU,(Image)oa[4],skillsMU));
            }

            foreach (var locationItem in location) {
                foreach (var muItem in MagicUserlst) {
                    if (locationItem.UserID.Equals(muItem)) {

                    }
                }
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
            string Qry1 = "SELECT * from " + tblName;
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
    }
}
