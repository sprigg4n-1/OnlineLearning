using EntityDAL.Models;
using EntityDAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Configuration
{
    public class TestQuestionConfiguration : IEntityTypeConfiguration<TestQuestion>
    {
        public void Configure(EntityTypeBuilder<TestQuestion> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.QuestionText).IsRequired().HasMaxLength(256);

            builder.HasOne(x => x.TestModel)
                .WithMany(x => x.TestQuestions)
                .HasForeignKey(x => x.TestModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Questions_TestId"); ;


            new TestQuestionSeeder().Seed(builder);
        }
    }
}
