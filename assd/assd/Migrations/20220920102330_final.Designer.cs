﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assd;

namespace assd.Migrations
{
    [DbContext(typeof(school))]
    [Migration("20220920102330_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("assd.regform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("RegForms");
                });

            modelBuilder.Entity("assd.regformitem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegFormId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegFormId");

                    b.HasIndex("SubjectId");

                    b.ToTable("RegFormItems");
                });

            modelBuilder.Entity("assd.student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegFormId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("assd.subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("assd.regform", b =>
                {
                    b.HasOne("assd.student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("assd.regformitem", b =>
                {
                    b.HasOne("assd.regform", "RegForm")
                        .WithMany("Items")
                        .HasForeignKey("RegFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("assd.subject", "Subject")
                        .WithMany("Items")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegForm");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("assd.student", b =>
                {
                    b.HasOne("assd.regform", "RegForm")
                        .WithMany()
                        .HasForeignKey("RegFormId");

                    b.Navigation("RegForm");
                });

            modelBuilder.Entity("assd.regform", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("assd.subject", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
