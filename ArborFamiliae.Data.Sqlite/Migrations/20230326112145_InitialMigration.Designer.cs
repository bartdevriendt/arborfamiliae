﻿// <auto-generated />
using System;
using ArborFamiliae.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArborFamiliae.Data.Sqlite.Migrations
{
    [DbContext(typeof(ArborFamiliaeContext))]
    [Migration("20230326112145_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ArborFamiliae.Data.Models.ArborEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("PlaceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FatherId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("MotherId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.HasIndex("MotherId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.FamilyChild", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("FamilyChildren");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SortOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Name", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Call")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamiliyNickName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NameType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suffix")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.PersonEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventRole")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonEvents");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Place", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ArborId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EnclosedById")
                        .HasColumnType("TEXT");

                    b.Property<float?>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<float?>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EnclosedById");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Sequence", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("NextValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SequenceType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("ArborFamiliae.Data.Models.Surname", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Connector")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NameId")
                        .HasColumnType("TEXT");

                    b.Property<int>("OriginType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prefix")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Primary")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SurnameValue")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("ArborFamiliae.Data.Models.Place", b =>
                {
                    b.HasOne("ArborFamiliae.Data.Models.Place", "EnclosedBy")
                        .WithMany("Enclosing")
                        .HasForeignKey("EnclosedById");

                    b.Navigation("EnclosedBy");
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

            modelBuilder.Entity("ArborFamiliae.Data.Models.Place", b =>
                {
                    b.Navigation("Enclosing");
                });
#pragma warning restore 612, 618
        }
    }
}
