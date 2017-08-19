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
    public class DbConnection
    {
        private MySqlConnection connection;
        private string connectionString;
        private string server = "localhost";
        private string database = "trumptweeterbot";
        private string uid = "root";
        private string password = "";

        // Initializes this string whenever the DbConnection class is called.
        public DbConnection()
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }

        // Here is where we insert our data in the
        // database

        public void Insert(string title, string image)
        {
            // This is the sql command which uses
            // parameters to avoid things like
            // sql injection attacks

            // Inserting new potential tweets to the database.
            // Using statement will open the connection, perform the action, then close the connection at the end of the using statement.
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insert = "INSERT INTO imageurls(post_title, image_url, post_date, has_been_posted) VALUES(@post_title,@image_url,@post_date, @has_been_posted);";

                    Console.WriteLine("Inserting my data into your table. Giggity!");

                    // Here are the parameters for our sql command

                    using (MySqlCommand cmd = new MySqlCommand(insert, connection))
                    {
                        cmd.Parameters.Add("@post_title", MySqlDbType.String).Value = title.Replace("'", "");
                        cmd.Parameters.Add("@image_url", MySqlDbType.String).Value = image;
                        cmd.Parameters.Add("@post_date", MySqlDbType.Date).Value = DateTime.Now;
                        cmd.Parameters.Add("@has_been_posted", MySqlDbType.Int32).Value = 0;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not connect to database!");
                }
            }
        }

        // Here is the method used for counting
        // the number of rows we have in the
        // database

        public int GetNumberOfRows()
        {
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string countCommand = "SELECT COUNT(*) FROM imageurls";

                    using (MySqlCommand cnt = new MySqlCommand(countCommand, connection))
                    {
                        return Convert.ToInt32(cnt.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not connect to database!");
                    return 0;
                    // returns 0 if there is no connection to the database.
                }
            }
        }

        public Twitter HasBeenPosted()
        {
            // SQL query that will find all rows
            // whose has_been_posted colum = 0
            // so we don't send duplicate tweets  

            var twitter = new Twitter();
            string selectRandom = "SELECT * FROM `imageurls` WHERE `has_been_posted` IN (SELECT `has_been_posted` FROM `imageurls` GROUP BY `has_been_posted` HAVING COUNT(*) > 1) ORDER BY rand() LIMIT @limit";

            int limit = 5;

            using (MySqlCommand select = new MySqlCommand(selectRandom, connection))
            {
                select.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;

                using (MySqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // checking the contents of the items
                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine(reader.GetString(1));

                        // assigning the db items to a twitter object
                        twitter.title = reader.GetString(0);
                        twitter.image = reader.GetString(1);

                        // returning that object
                        return twitter;
                    }
                }
                return twitter;
            }
        }
    }
}
