﻿// <auto-generated />
using System;
using ArborFamiliae.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArborFamiliae.Data.Mysql.Migrations
{
    [DbContext(typeof(ArborFamiliaeContext))]
    [Migration("20230311132334_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArborFamiliae.Data.Models.ArborEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("EventDate")
                        .HasColumnType("longtext");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("FatherId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("MotherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.HasIndex("MotherId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.FamilyChild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("FamilyChildren");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Name", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Call")
                        .HasColumnType("longtext");

                    b.Property<string>("FamiliyNickName")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NameType")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Suffix")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.PersonEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("char(36)");

                    b.Property<int>("EventRole")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonEvents");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Sequence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("NextValue")
                        .HasColumnType("int");

                    b.Property<string>("SequenceType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Surname", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Connector")
                        .HasColumnType("longtext");

                    b.Property<Guid>("NameId")
                        .HasColumnType("char(36)");

                    b.Property<int>("OriginType")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .HasColumnType("longtext");

                    b.Property<bool>("Primary")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SurnameValue")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NameId");

                    b.ToTable("Surname");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.ArborEvent", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Family", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Person", "Father")
                        .WithMany()
                        .HasForeignKey("FatherId");

                    b.HasOne("ArborFamiliae.Data.Models.Person", "Mother")
                        .WithMany()
                        .HasForeignKey("MotherId");

                    b.Navigation("Father");

                    b.Navigation("Mother");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.FamilyChild", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Person", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArborFamiliae.Data.Models.Family", "Family")
                        .WithMany("Children")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Name", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Person", "Person")
                        .WithMany("Names")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Person", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.PersonEvent", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.ArborEvent", "Event")
                        .WithMany("PersonEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArborFamiliae.Data.Models.Person", "Person")
                        .WithMany("Events")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Surname", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Name", "Name")
                        .WithMany("Surnames")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Name");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.ArborEvent", b =>
                {
                    b.Navigation("PersonEvents");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Family", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Name", b =>
                {
                    b.Navigation("Surnames");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Person", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Names");
                });
#pragma warning restore 612, 618
        }
    }
}
