using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PowerTools.Models.Mapping
{
    public class tblWorkoutMap : EntityTypeConfiguration<tblWorkout>
    {
        public tblWorkoutMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkoutId);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblWorkout");
            this.Property(t => t.WorkoutId).HasColumnName("WorkoutId");
            this.Property(t => t.WorkoutTypeId).HasColumnName("WorkoutTypeId");
            this.Property(t => t.WeatherId).HasColumnName("WeatherId");
            this.Property(t => t.RouteId).HasColumnName("RouteId");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.TotalTime).HasColumnName("TotalTime");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.DiaryFeelingId).HasColumnName("DiaryFeelingId");

            // Relationships
            this.HasOptional(t => t.tblDiaryFeeling)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.DiaryFeelingId);
            this.HasRequired(t => t.tblWorkoutType)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.WorkoutTypeId);

        }
    }
}
