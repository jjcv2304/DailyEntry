using System.Data.Entity;
using DailyEntry.Core.Model;
using DailyEntry.Infrastructure.Mapping;

namespace DailyEntry.Infrastructure
{
    public partial class TrainningDB : DbContext
    {
        static TrainningDB()
        {
            Database.SetInitializer<TrainningDB>(null);
        }

        public TrainningDB()
            : base("Name=TrainningDB")
        {
          //  base.OnModelCreating(modelBuilder);
        }

        public DbSet<DailyFeeling> DailyFeelings { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutType> WorkoutTypes { get; set; }
        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<AuthToken> AuthTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DailyFeelingMap());
            modelBuilder.Configurations.Add(new WorkoutMap());
            modelBuilder.Configurations.Add(new WorkoutTypeMap());
            modelBuilder.Configurations.Add(new ApiUserMap());
            modelBuilder.Configurations.Add(new AuthTokenMap());
        }

    }
}
