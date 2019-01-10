using HC.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace HC.Core.DataBase
{
    public class OrderDbContext : DbContext
    {
        public string ConnectionString
        {
            get
            {
                //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\repos\OrderSystem\HC.Core\App_Data\Database1.mdf;Integrated Security=True
                //var path = Path.Combine(Directory.GetCurrentDirectory(), @"App_Data\Database1.mdf");
                var path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\repos\OrderSystem\HC.Core\App_Data\Database1.mdf;Integrated Security=True";


                return path;
                //return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True";

            }

        }
        public DbSet<Product> Product { get; set; }
        public OrderDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }



    }
}
