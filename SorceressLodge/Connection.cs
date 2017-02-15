using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SorceressLodge {
    class Connection {
        SqlConnection sqlconn;
        SqlCommand sqlcomm;
        SqlDataReader datareader;

        public Connection() {
            string conn = @"Data Source=DESKTOP-103SE6A\SQLEXPRESS;Initial Catalog=SorceressLodge;Integrated Security=True";
            sqlconn = new SqlConnection(conn);
        }

        public List<MagicUser> ReadMagicUser() {
            List<MagicUser> MagicUserlst = new List<MagicUser>();
            return MagicUserlst;
        }

        public List<Users> ReadUsers() {
            List<Users> Userslst = new List<Users>();
            sqlconn.Open();
            string Qry1 = "SELECT * from Users";
            sqlcomm = new SqlCommand(Qry1,sqlconn);
            datareader = sqlcomm.ExecuteReader();
            while (datareader.Read()) {
                string UserName = datareader.GetValue(1).ToString();
                string Password = datareader.GetValue(2).ToString();
                Userslst.Add(new Users(UserName, Password));
            }
            sqlconn.Close();
            return Userslst;
        }

        public List<MagicType> ReadMagicType() {
            List<MagicType> MagicTypelst = new List<MagicType>();
            sqlconn.Open();
            string Qry1 = "SELECT * from MagicTypes";
            sqlcomm = new SqlCommand(Qry1, sqlconn);
            datareader = sqlcomm.ExecuteReader();
            while (datareader.Read()) {
                int ID = Convert.ToInt32(datareader.GetValue(0));
            }
            sqlconn.Close();
            return MagicTypelst;
        }
    }
}
