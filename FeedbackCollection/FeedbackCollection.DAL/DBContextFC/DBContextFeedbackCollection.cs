using Microsoft.EntityFrameworkCore;
namespace FeedbackCollection.DAL.DBContextFC
{
    public class DBContextFeedbackCollection: DbContext
    {
        public DBContextFeedbackCollection(DbContextOptions<DBContextFeedbackCollection> options)
            : base(options)
        {
        }
        //public DbSet<NecessaryGLModel> NecessaryGLDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<NecessaryGLModel>().ToTable("NECESSARY_GL", "CardReward");
        }
    }
}
