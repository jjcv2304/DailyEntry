using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace DailyEntry.Infrastructure.Mapping
{
    public class WorkoutTypeMap : EntityTypeConfiguration<WorkoutType>
    {
        public WorkoutTypeMap()
        {
            // Primary Key
           // this.HasKey(t => t.WorkoutTypeId);

            // Properties
            //this.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblWorkoutType");
            this.Property(t => t.WorkoutTypeId).HasColumnName("WorkoutTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
