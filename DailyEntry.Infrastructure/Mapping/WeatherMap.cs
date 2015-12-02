using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace powertools.Models.Mapping
{
    public class WeatherMap : EntityTypeConfiguration<Weather>
    {
        public WeatherMap()
        {
            // Primary Key
            //.HasKey(t => t.WeatherId);

            // Properties
            //this.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblWeather");
            this.Property(t => t.WeatherId).HasColumnName("WeatherId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
