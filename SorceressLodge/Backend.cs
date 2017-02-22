using System;
using System.Collections.Generic;
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

        public DataGridView SearchUsers(Dictionary<string, object> searchTerms) {

            string conn = @"Data Source=DESKTOP-C12M830\SQLEXPRESS;Initial Catalog=first;Integrated Security=True";

            sqlConnect = new SqlConnection(conn);
            sqlConnect.Open();

            string Query1 = "SELECT * from Store_Details";

            sqlCommand = new SqlCommand(Query1, sqlConnect);
            dataAdapt = new SqlDataAdapter(sqlCommand);
            dataset = new DataSet();
            dataAdapt.Fill(dataset, "Store_Details");
            commBuilder = new SqlCommandBuilder(dataAdapt);
            dataTable = dataset.Tables["Store_Details"];
            sqlConnect.Close();

            //MessageBox.Show(dataTable.TableName.ToString());
            //MessageBox.Show(dataset.DataSetName.ToString());

            dataGridView1.DataSource = dataTable;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;


        }

    }
}
