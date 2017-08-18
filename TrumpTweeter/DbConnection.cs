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
        
        // This method is used to initialize our connection
        // to our database

        public void ConnectingToDb(string title, string image)
        {
            server = "localhost";
            database = "trumptweeterbot";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            OpenConnection(title, image);
        }

        // This method is where we open our connnection to the sql
        // database and call the Insert() method which inserts
        // the title of the post and the image url into the database

        private void OpenConnection(string title, string image)
        {
            // Here we check if the connection is already open
            // then we call the Insert() method to send the data
            // If the connection is closed then we open it and
            // call our Insert() method to send the data

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Connected to the database!");
                Insert(title, image);
                CloseConnection();              
            }
            else if (connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Already connected to the database.");
                Insert(title, image);
                CloseConnection();
            }
        }

        // Here is where we close our connection but
        // first we check to see if the connection is
        // open
        // If it's open then we call our GetNumberOfRows()
        // method to check how many rows we have in 
        // our table to help us keep track of tweets
        // Once we have our row numbers we close the
        // connection

        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                HasBeenPosted();
                GetNumberOfRows();
                int numberOfRows = GetNumberOfRows();
                connection.Close();
            }
            
        }

        // Here is where we insert our data in the
        // database
        // First we check if the connection is open
        // then we send our sql command to insert
        // the data

        public void Insert(string title, string image)
        {            
            // This is the sql command which uses
            // parameters to avoid things like
            // sql injection attacks

            string insert = "INSERT INTO imageurls(post_title, image_url, post_date) VALUES(@post_title,@image_url,@post_date);";

            if(connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Inserting my data into your table. Giggity!");

                // Here are the parameters for our sql command

                using (MySqlCommand cmd = new MySqlCommand(insert, connection))
                {
                    cmd.Parameters.Add("@post_title", MySqlDbType.String).Value = title.Replace("'", "");
                    cmd.Parameters.Add("@image_url", MySqlDbType.String).Value = image;
                    cmd.Parameters.Add("@post_date", MySqlDbType.Date).Value = DateTime.Now;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Here is the method used for counting
        // the number of rows we have in the
        // database

        public int GetNumberOfRows()
        {
            string countCommand = "SELECT COUNT(*) FROM imageurls";

            using (MySqlCommand cnt = new MySqlCommand(countCommand, connection))
            {
                return Convert.ToInt32(cnt.ExecuteScalar());
            }
        }

        public void HasBeenPosted()
        {
            // SQL query that will find all rows
            // whose has_been_posted colum = 0
            // so we don't send duplicate tweets

            string selectCommand = "SELECT * FROM `imageurls` WHERE `has_been_posted` IN (SELECT `has_been_posted` FROM `imageurls` GROUP BY `has_been_posted` HAVING COUNT(*) > 1)";


            using (MySqlCommand select = new MySqlCommand(selectCommand, connection))
            {
                using (MySqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine(reader.GetString(1));
                    }
                }
            }
        }
    }
}
