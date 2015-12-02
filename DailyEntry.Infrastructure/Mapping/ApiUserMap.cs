using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class ApiUserMap : EntityTypeConfiguration<ApiUser>
    {
        public ApiUserMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("Apiuser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Secret).HasColumnName("Secret");
            this.Property(t => t.AppId).HasColumnName("AppId");
        }
    }
}


 