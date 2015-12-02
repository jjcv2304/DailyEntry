using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class AuthTokenMap : EntityTypeConfiguration<AuthToken>
    {
        public AuthTokenMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("AuthToken");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.Expiration).HasColumnName("Expiration");
            this.Property(t => t.ApiUserId).HasColumnName("ApiUser_Id");

            this.HasRequired(t => t.ApiUser)
                .WithMany(t => t.AuthTokens)
                .HasForeignKey(d => d.ApiUserId);
        }
    }
}


 