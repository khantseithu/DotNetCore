using System;
using System.Data.SqlClient;

namespace DotNetCore.ConsoleApp
{
    public class DatabaseConnection
    {
        private const string ConnectionString = "Server=localhost,1433;Database=DotNetTrainingBatch4;User Id=sa;Password=YourStrong@Passw0rd";

        public SqlConnection GetConnection() 
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            Console.WriteLine("Connected to database");
            return connection;
        }

        public void CreateBlog(Blog blog) 
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Blog (Title, Content) VALUES (@Title, @Content)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@Content", blog.Content);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Blog created successfully");
                }
                else
                {
                    Console.WriteLine("Failed to create blog");
                }
            }
        }

        public void ReadBlog()
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Blog";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string content = reader.GetString(2);
                    Console.WriteLine($"Id: {id}, Title: {title}, Content: {content}");
                }
            }
        }

        public void UpdateBlog(Blog blog)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "UPDATE Blog SET Title = @Title, Content = @Content WHERE BlogId = @BlogId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BlogId", blog.Id);
                command.Parameters.AddWithValue("@Title", blog.Title);
                command.Parameters.AddWithValue("@Content", blog.Content);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0) 
                {
                    Console.WriteLine("Blog updated successfully");
                }
                else
                {
                    Console.WriteLine("Blog not found");
                }
            }
        }

        public void DeleteBlog(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "DELETE FROM Blog WHERE BlogId = @BlogId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BlogId", id);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Blog deleted successfully");
                }
                else
                {
                    Console.WriteLine("Blog not found");
                }
            }
        }
    }
} // Added closing brace for DatabaseConnection class
