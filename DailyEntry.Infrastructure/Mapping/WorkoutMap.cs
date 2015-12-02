using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace powertools.Models.Mapping
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
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.WorkoutTypeId).HasColumnName("WorkoutTypeId");
            this.Property(t => t.WeatherId).HasColumnName("WeatherId");
            this.Property(t => t.RouteId).HasColumnName("RouteId");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.TimeSpend).HasColumnName("TimeSpend");
            this.Property(t => t.TotalTime).HasColumnName("TotalTime");
            this.Property(t => t.TimeZone1).HasColumnName("TimeZone1");
            this.Property(t => t.TimeZone2).HasColumnName("TimeZone2");
            this.Property(t => t.TimeZone3).HasColumnName("TimeZone3");
            this.Property(t => t.TimeZone4).HasColumnName("TimeZone4");
            this.Property(t => t.TimeZone5).HasColumnName("TimeZone5");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Temperature).HasColumnName("Temperature");
            this.Property(t => t.DiaryFeelingId).HasColumnName("DiaryFeelingId");

            // Relationships
            this.HasOptional(t => t.DiaryFeeling)
                .WithMany(t => t.Workouts)
                .HasForeignKey(d => d.DiaryFeelingId);
           
            this.HasOptional(t => t.Route)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.RouteId);
            
            this.HasOptional(t => t.Weather)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.WeatherId);
           
            this.HasRequired(t => t.WorkoutType)
                .WithMany(t => t.tblWorkouts)
                .HasForeignKey(d => d.WorkoutTypeId);

        }
    }
}
