using EntityDAL.Models;
using EntityDAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Configuration
{
    public class TestModelConfiguration : IEntityTypeConfiguration<TestModel>
    {
        public void Configure(EntityTypeBuilder<TestModel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Title).IsRequired().HasMaxLength(128);
            builder.Property(t => t.Description).IsRequired(false).HasMaxLength(256);
            builder.Property(t => t.TimeLimit).IsRequired();

            new TestModelSeeder().Seed(builder);
        }
    }
}
