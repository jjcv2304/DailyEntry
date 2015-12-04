using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class WorkoutMap : EntityTypeConfiguration<Workout>
    {
        public WorkoutMap()
        {
            // Primary Key
            //this.HasKey(t => t.WorkoutId);

            // Properties
            // Table & Column Mappings
            this.ToTable("tblWorkout");
            this.Property(t => t.WorkoutId).HasColumnName("WorkoutId");
            this.Property(t => t.WorkoutTypeId).HasColumnName("WorkoutTypeId");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.TotalTime).HasColumnName("TotalTime");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.DiaryFeelingId).HasColumnName("DiaryFeelingId");

            // Relationships
            this.HasOptional(t => t.DiaryFeeling)
                .WithMany(t => t.Workouts)
                .HasForeignKey(d => d.DiaryFeelingId);
           
            this.HasRequired(t => t.WorkoutType)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.WorkoutTypeId);

        }
    }
}
