using Microsoft.EntityFrameworkCore;
using System.CodeDom;
using My_App.Models;

namespace My_App.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDBContext()
        {
        }
        public DbSet<Customer> Customer { get; set; } = null!;
    }
}
