using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PowerTools.Models.Mapping
{
    public class tblDiaryFeelingMap : EntityTypeConfiguration<tblDiaryFeeling>
    {
        public tblDiaryFeelingMap()
        {
            // Primary Key
            this.HasKey(t => t.DiaryFeelingId);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblDiaryFeeling");
            this.Property(t => t.DiaryFeelingId).HasColumnName("DiaryFeelingId");
            this.Property(t => t.Sleep).HasColumnName("Sleep");
            this.Property(t => t.Fatigue).HasColumnName("Fatigue");
            this.Property(t => t.Stress).HasColumnName("Stress");
            this.Property(t => t.Soreness).HasColumnName("Soreness");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.RestingHeartRate).HasColumnName("RestingHeartRate");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.DiaryUserId).HasColumnName("DiaryUserId");

            // Relationships
            this.HasOptional(t => t.DiaryUser)
                .WithMany(t => t.tblDiaryFeelings)
                .HasForeignKey(d => d.DiaryUserId);

        }
    }
}
