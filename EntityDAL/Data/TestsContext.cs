using EntityDAL.Configuration;
using EntityDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDAL.Data
{
    public class TestsContext : DbContext
    {


        public DbSet<TestModel> Tests { get; set; }
        public DbSet<TestQuestion> TestsQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TestModelConfiguration());
            modelBuilder.ApplyConfiguration(new TestQuestionConfiguration());
        }

        public TestsContext(DbContextOptions<TestsContext> options) : base(options)
        {

        }


    }
}
