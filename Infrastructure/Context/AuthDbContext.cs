using Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Database
{
    public sealed class AuthDbContext: DbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Application> Application { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Enterprise> Enterprise { get; set; }
        public DbSet<PermissionRole> PermissionRole { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Registers> Registers { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ForSqlServerUseIdentityColumns()
                .ApplyConfiguration(new UserLogEntityTypeConfiguration());
        }
    }
}
