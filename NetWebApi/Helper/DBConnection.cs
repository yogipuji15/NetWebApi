using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NetWebApi.Models.Entity;

namespace NetWebApi.Helper
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }


    }
}
