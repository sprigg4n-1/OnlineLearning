using EntityDAL.Interfaces;
using EntityDAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Seeding
{
    public class TestModelSeeder : ISeeder<TestModel>
    {
        private static readonly List<TestModel> tests = new()
        {
            new TestModel
                {
                    Id = 2,
                    Title = "Поглиблене вивчення C#",
                    Description = "Курс призначений для студентів, які хочуть глибше зануритися в мову C#.",
                    TimeLimit = new TimeSpan(35, 0, 0),
                    CourseId = 2
                },

            new TestModel
                {
                    Id = 1,
                    Title = "Вступ до програмування",
                    Description = "Цей курс знайомить студентів з основами програмування, використовуючи C#.",
                    TimeLimit = new TimeSpan(20, 0, 0),
                    CourseId = 1
            }
        };

        public void Seed(EntityTypeBuilder<TestModel> builder) => builder.HasData(tests);
    }
}
