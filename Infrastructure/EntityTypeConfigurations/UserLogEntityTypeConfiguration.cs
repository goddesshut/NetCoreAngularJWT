using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Infrastructure.EntityTypeConfigurations
{
    public sealed class UserLogEntityTypeConfiguration: IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.ToTable("UserLogs", "dbo");
            builder.HasKey(x => x.LogId);

            builder.Property(x => x.LogId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.ELoginType).IsRequired();
            builder.Property(x => x.LoginType).IsRequired();
        }
    }
}
