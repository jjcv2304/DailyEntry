using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PowerTools.Models.Mapping;

namespace PowerTools.Models
{
    public partial class DailyTrainingContext : DbContext
    {
        static DailyTrainingContext()
        {
            Database.SetInitializer<DailyTrainingContext>(null);
        }

        public DailyTrainingContext()
            : base("Name=DailyTrainingContext")
        {
        }

        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<DiaryUser> DiaryUsers { get; set; }
        public DbSet<tblDiaryFeeling> tblDiaryFeelings { get; set; }
        public DbSet<tblWorkout> tblWorkouts { get; set; }
        public DbSet<tblWorkoutType> tblWorkoutTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new DiaryUserMap());
            modelBuilder.Configurations.Add(new tblDiaryFeelingMap());
            modelBuilder.Configurations.Add(new tblWorkoutMap());
            modelBuilder.Configurations.Add(new tblWorkoutTypeMap());
        }
    }
}
