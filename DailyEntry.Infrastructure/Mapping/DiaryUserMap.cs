using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class DiaryUserMap : EntityTypeConfiguration<DiaryUser>
    {
        public DiaryUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Username)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("DiaryUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Username).HasColumnName("Username");
        }
    }
}

