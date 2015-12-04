using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class DailyFeelingMap : EntityTypeConfiguration<DailyFeeling>
    {
        public DailyFeelingMap()
        {
            // Primary Key
            this.HasKey(t => t.DailyFeelingId);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblDiaryFeeling");
            this.Property(t => t.DailyFeelingId).HasColumnName("DiaryFeelingId");
            this.Property(t => t.Sleep).HasColumnName("Sleep");
            this.Property(t => t.Fatigue).HasColumnName("Fatigue");
            this.Property(t => t.Stress).HasColumnName("Stress");
            this.Property(t => t.Soreness).HasColumnName("Soreness");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.RestingHeartRate).HasColumnName("RestingHeartRate");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.DiaryuserId).HasColumnName("DiaryuserId");

            // Relationships
            this.HasOptional(t => t.DiaryUser)
                .WithMany(t => t.DailyFeelings)
                .HasForeignKey(d => d.DiaryuserId);

        }
    }
}
