﻿// <auto-generated />
using System;
using EntityDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityDAL.Migrations
{
    [DbContext(typeof(TestsContext))]
    partial class TestsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityDAL.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<TimeSpan>("TimeLimit")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            Description = "Курс призначений для студентів, які хочуть глибше зануритися в мову C#.",
                            TimeLimit = new TimeSpan(1, 11, 0, 0, 0),
                            Title = "Поглиблене вивчення C#"
                        },
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Description = "Цей курс знайомить студентів з основами програмування, використовуючи C#.",
                            TimeLimit = new TimeSpan(0, 20, 0, 0, 0),
                            Title = "Вступ до програмування"
                        });
                });

            modelBuilder.Entity("EntityDAL.Models.TestQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("TestModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestModelId");

                    b.ToTable("TestsQuestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionText = "Що таке змінна в C#?",
                            TestModelId = 1
                        },
                        new
                        {
                            Id = 2,
                            QuestionText = "Яка з цих конструкцій є циклом у C#?",
                            TestModelId = 1
                        },
                        new
                        {
                            Id = 3,
                            QuestionText = "Що таке клас у об'єктно-орієнтованому програмуванні?",
                            TestModelId = 1
                        },
                        new
                        {
                            Id = 4,
                            QuestionText = "Що таке алгоритм?",
                            TestModelId = 2
                        },
                        new
                        {
                            Id = 5,
                            QuestionText = "Яка структура даних є найкращою для реалізації стеку?",
                            TestModelId = 2
                        },
                        new
                        {
                            Id = 6,
                            QuestionText = "Що таке складність алгоритму?",
                            TestModelId = 2
                        });
                });

            modelBuilder.Entity("EntityDAL.Models.TestQuestion", b =>
                {
                    b.HasOne("EntityDAL.Models.TestModel", "TestModel")
                        .WithMany("TestQuestions")
                        .HasForeignKey("TestModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Questions_TestId");

                    b.Navigation("TestModel");
                });

            modelBuilder.Entity("EntityDAL.Models.TestModel", b =>
                {
                    b.Navigation("TestQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
