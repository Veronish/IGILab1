﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab1core;

namespace lab1core.Migrations
{
    [DbContext(typeof(CheckContext))]
    partial class CheckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab1core.Modules.Check", b =>
                {
                    b.Property<int>("CheckID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CorrectionPeriod");

                    b.Property<DateTime>("Date");

                    b.Property<float>("Fine");

                    b.Property<int>("InspectorId");

                    b.Property<int>("InterpriseId");

                    b.Property<int>("ProtocolNumber");

                    b.Property<string>("Responsible");

                    b.Property<int>("ViolationId");

                    b.HasKey("CheckID");

                    b.HasIndex("InspectorId");

                    b.HasIndex("InterpriseId");

                    b.HasIndex("ViolationId");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("lab1core.Modules.Inspector", b =>
                {
                    b.Property<int>("InspectorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InspectorName");

                    b.Property<string>("InspectorSurname");

                    b.Property<string>("Unit");

                    b.HasKey("InspectorId");

                    b.ToTable("Inspectors");
                });

            modelBuilder.Entity("lab1core.Modules.Interprise", b =>
                {
                    b.Property<int>("InterpriseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("BossInfo");

                    b.Property<string>("FormOfOwership");

                    b.Property<string>("NameInterprise");

                    b.HasKey("InterpriseId");

                    b.ToTable("Interprises");
                });

            modelBuilder.Entity("lab1core.Modules.Violation", b =>
                {
                    b.Property<int>("ViolationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CorrectionPeriod");

                    b.Property<float>("Fine");

                    b.Property<string>("NameViolation");

                    b.HasKey("ViolationId");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("lab1core.Modules.Check", b =>
                {
                    b.HasOne("lab1core.Modules.Inspector", "Inspector")
                        .WithMany()
                        .HasForeignKey("InspectorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("lab1core.Modules.Interprise", "Interprise")
                        .WithMany()
                        .HasForeignKey("InterpriseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("lab1core.Modules.Violation", "Violation")
                        .WithMany()
                        .HasForeignKey("ViolationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
