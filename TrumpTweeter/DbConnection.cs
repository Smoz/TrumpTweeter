using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TrumpTweeter
{
    class DbConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        public void ConnectingToDb()
        {
            server = "localhost";
            database = "trumptweeterbot";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            OpenConnection();
        }

        private void OpenConnection()
        {          
            
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Connected to the database!");
                Insert();
                CloseConnection();              
            }
            else if (connection.State == ConnectionState.Closed)
            {
                Console.WriteLine("Already connected to the database.");
                Insert();
                CloseConnection();
            }
        }
        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void Insert()
        {            

            string insert = "INSERT INTO imageurls(post_title, image_url, post_date) VALUES('test title', 'test url', '');";

            if(connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Inserting my data into your table. Giggity!");
                MySqlCommand cmd = new MySqlCommand(insert, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
