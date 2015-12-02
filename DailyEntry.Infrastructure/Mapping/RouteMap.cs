using System.Data.Entity.ModelConfiguration;
using DailyEntry.Core.Model;

namespace powertools.Models.Mapping
{
    public class RouteMap : EntityTypeConfiguration<Route>
    {
        public RouteMap()
        {
            // Primary Key
           // this.HasKey(t => t.RouteId);

            // Properties
            //this.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblRoute");
            this.Property(t => t.RouteId).HasColumnName("RouteId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
