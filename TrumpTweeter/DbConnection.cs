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

        // SQL query that will find all rows
        // whose has_been_posted colum = 0
        // so we don't send duplicate tweets 
        
        public List<Twitter> GetTweets()
        {
            
            using (connection = new MySqlConnection(connectionString))
            {              

                // SQL command to check for 0's in the has_been_posted
                // column and return a random selection of posts for
                // the limit set
                // Need to add some randomization to the limit for
                // more humanlike behavior (aka posting)
                string lookForZeros = "SELECT * FROM `imageurls` WHERE `has_been_posted` IN (SELECT `has_been_posted` FROM `imageurls` GROUP BY `has_been_posted` HAVING COUNT(*) > 1) ORDER BY rand() LIMIT @limit";

                // List of tweets not posted yet
                var tweetsNotPosted = new List<Twitter>();

                // Number of tweets to attempt to post
                int limit = 5;

                using (var cmd = new MySqlCommand(lookForZeros, connection))
                {
                    connection.Open();
                    
                    cmd.Parameters.Add("@limit", MySqlDbType.Int32).Value = limit;
                    var reader = cmd.ExecuteReader();

                    // puts tweets that haven't posted into Twitter object list
                    while (reader.Read())
                    {
                        var twitter = new Twitter
                        {
                            Title = reader[0].ToString(),
                            Image = reader[1].ToString()
                        };

                        tweetsNotPosted.Add(twitter);

                        // update has_been_posted to 1
                        HasBeenPosted(reader[1].ToString());
                    }
                    return tweetsNotPosted;
                }
            }
        }

        // Changes has_been_posted column to 1
        public void HasBeenPosted(string image)
        {
            string update = "UPDATE imageurls SET has_been_posted = 1 WHERE image_url LIKE @image_url";

            using (connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var cmd = new MySqlCommand(update, connection))
                {
                    cmd.Parameters.Add("@image_url", MySqlDbType.Text).Value = image;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
