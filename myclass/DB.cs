using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace UFCfinal.myclass
{
    class DB
    {
        public MySqlConnection connection;

        public DB()
        {
            string server = "localhost";
            string database = "BP2Projekt";
            string port = "3306";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "PORT=" + port + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

    }
    class CRUD:DB
    {

        // PROP

        public int id_sudac { get; set; }
        public string ime_sudac { get; set; }
        public string prezime_sudac { get; set; }
        public int zemlja_id { get; set; }

        // READ

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        // CREATE FUNCTIOM

        public void CreateData()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO sudac(ime_sudac, prezime_sudac, zemlja_id) VALUES(@ime, @prezime, @zemlja); ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@ime", MySqlDbType.VarChar).Value = ime_sudac;
                cmd.Parameters.Add("@prezime", MySqlDbType.VarChar).Value = prezime_sudac;
                cmd.Parameters.Add("@zemlja", MySqlDbType.Int32).Value = zemlja_id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        // UPDATE FUNCTION

        public void UpdateData()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE sudac SET ime_sudac=@ime, prezime_sudac=@prezime, zemlja_id=@zemlja WHERE id_sudac=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@ime", MySqlDbType.VarChar).Value = ime_sudac;
                cmd.Parameters.Add("@prezime", MySqlDbType.VarChar).Value = prezime_sudac;
                cmd.Parameters.Add("@zemlja", MySqlDbType.Int32).Value = zemlja_id;

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_sudac;


                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // DELETE

        public void DeleteData()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM sudac WHERE id_sudac=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_sudac;


                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // READ 

        public void ReadData()
        {
            dt.Clear();
            string query = "SELECT * from sudac";
            MySqlDataAdapter mySqlData = new MySqlDataAdapter(query, connection);
            mySqlData.Fill(ds);
            dt = ds.Tables[0];
        }

    }

}
