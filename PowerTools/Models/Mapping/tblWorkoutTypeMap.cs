using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PowerTools.Models.Mapping
{
    public class tblWorkoutTypeMap : EntityTypeConfiguration<tblWorkoutType>
    {
        public tblWorkoutTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.WorkoutTypeId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblWorkoutType");
            this.Property(t => t.WorkoutTypeId).HasColumnName("WorkoutTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
