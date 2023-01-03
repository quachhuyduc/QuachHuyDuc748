using QuachHuyDuc748.Models;
using Microsoft.EntityFrameworkCore;

namespace QuachHuyDuc748.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CompanyQHD748> Companies {get;set;}
    }
}