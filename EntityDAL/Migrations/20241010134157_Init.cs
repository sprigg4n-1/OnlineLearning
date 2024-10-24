using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityDAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TimeLimit = table.Column<TimeSpan>(type: "time", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestsQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TestModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestsQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_TestId",
                        column: x => x.TestModelId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Description", "TimeLimit", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Цей курс знайомить студентів з основами програмування, використовуючи C#.", new TimeSpan(0, 20, 0, 0, 0), "Вступ до програмування" },
                    { 2, 2, "Курс призначений для студентів, які хочуть глибше зануритися в мову C#.", new TimeSpan(1, 11, 0, 0, 0), "Поглиблене вивчення C#" }
                });

            migrationBuilder.InsertData(
                table: "TestsQuestions",
                columns: new[] { "Id", "QuestionText", "TestModelId" },
                values: new object[,]
                {
                    { 1, "Що таке змінна в C#?", 1 },
                    { 2, "Яка з цих конструкцій є циклом у C#?", 1 },
                    { 3, "Що таке клас у об'єктно-орієнтованому програмуванні?", 1 },
                    { 4, "Що таке алгоритм?", 2 },
                    { 5, "Яка структура даних є найкращою для реалізації стеку?", 2 },
                    { 6, "Що таке складність алгоритму?", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestsQuestions_TestModelId",
                table: "TestsQuestions",
                column: "TestModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestsQuestions");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
