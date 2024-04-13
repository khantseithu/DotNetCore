namespace DotNetCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();



            Blog blog = new Blog
            {
                Title = "Hello World",
                Content = "This is my second blog post"
            };
            dbConnection.CreateBlog(blog);

            dbConnection.ReadBlog();

            Blog updatedBlog = new Blog
            {
                Id = 1,
                Title = "Hello World 2",
                Content = "This is my updated blog post"
            };
            dbConnection.UpdateBlog(updatedBlog);

            dbConnection.DeleteBlog(2);    
        }
    }
}