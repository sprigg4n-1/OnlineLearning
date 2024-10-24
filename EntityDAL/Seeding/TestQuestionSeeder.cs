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
    public class TestQuestionSeeder: ISeeder<TestQuestion>
    {
        private static readonly List<TestQuestion> tests = new()
        {
            new TestQuestion
                {
                    Id = 1,
                    QuestionText = "Що таке змінна в C#?",
                    TestModelId = 1,
                },

            new TestQuestion
                {
                    Id = 2,
                    QuestionText = "Яка з цих конструкцій є циклом у C#?",
                    TestModelId = 1,
                },

            new TestQuestion
                {
                    Id = 3,
                    QuestionText = "Що таке клас у об'єктно-орієнтованому програмуванні?",
                    TestModelId = 1,
                },
            new TestQuestion
                {
                    Id = 4,
                    QuestionText = "Що таке алгоритм?",
                    TestModelId = 2,
                },
            new TestQuestion
                {
                    Id = 5,
                    QuestionText = "Яка структура даних є найкращою для реалізації стеку?",
                    TestModelId = 2,
                },
            new TestQuestion
                {
                    Id = 6,
                    QuestionText = "Що таке складність алгоритму?",
                    TestModelId = 2,
                }
        };

        public void Seed(EntityTypeBuilder<TestQuestion> builder) => builder.HasData(tests);
    }
}
