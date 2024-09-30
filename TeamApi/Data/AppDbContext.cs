using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using TeamApi.Models;

namespace TeamApi.Data {
    public class AppDbContext : DbContext {

        public DbSet<Time> Times { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=BancoTeam.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}


