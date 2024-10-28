using AJAXProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AJAXProject.DataAccess.Context
{
    public class AjaxContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=AjaxDb;integrated security=true;trustServerCertificate=true");
        }
        public DbSet<Product>  Products { get; set; }
    }
}
