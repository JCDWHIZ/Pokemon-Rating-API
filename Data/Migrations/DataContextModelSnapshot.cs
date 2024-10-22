﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Data;

#nullable disable

namespace ProductsApi.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2");

            modelBuilder.Entity("ProductsApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electric"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Grass"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kanto"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Saffron City"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pallet Town"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            FirstName = "Jack",
                            Gym = "Brock's Gym",
                            LastName = "London"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            FirstName = "Harry",
                            Gym = "Misty's Gym",
                            LastName = "Potter"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            FirstName = "Ash",
                            Gym = "Ash's Gym",
                            LastName = "Ketchum"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pikachu"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Squirtle"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1903, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Venusaur"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.PokemonCategory", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");

                    b.HasData(
                        new
                        {
                            PokemonId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            PokemonId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            PokemonId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.PokemonOwner", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PokemonOwners");

                    b.HasData(
                        new
                        {
                            PokemonId = 1,
                            OwnerId = 1
                        },
                        new
                        {
                            PokemonId = 2,
                            OwnerId = 2
                        },
                        new
                        {
                            PokemonId = 3,
                            OwnerId = 3
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PokemonId = 1,
                            Rating = 5,
                            ReviewerId = 1,
                            Text = "Pikachu is the best pokemon, because it is electric",
                            Title = "Pikachu"
                        },
                        new
                        {
                            Id = 2,
                            PokemonId = 2,
                            Rating = 5,
                            ReviewerId = 2,
                            Text = "Squirtle is the best water-type pokemon",
                            Title = "Squirtle"
                        },
                        new
                        {
                            Id = 3,
                            PokemonId = 3,
                            Rating = 5,
                            ReviewerId = 3,
                            Text = "Venusaur is the best grass-type pokemon",
                            Title = "Venusaur"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Teddy",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Taylor",
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jessica",
                            LastName = "McGregor"
                        });
                });

            modelBuilder.Entity("ProductsApi.Models.Owner", b =>
                {
                    b.HasOne("ProductsApi.Models.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ProductsApi.Models.PokemonCategory", b =>
                {
                    b.HasOne("ProductsApi.Models.Category", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsApi.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("ProductsApi.Models.PokemonOwner", b =>
                {
                    b.HasOne("ProductsApi.Models.Owner", "Owner")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsApi.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("ProductsApi.Models.Review", b =>
                {
                    b.HasOne("ProductsApi.Models.Pokemon", "Pokemon")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsApi.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("ProductsApi.Models.Category", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("ProductsApi.Models.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("ProductsApi.Models.Owner", b =>
                {
                    b.Navigation("PokemonOwners");
                });

            modelBuilder.Entity("ProductsApi.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ProductsApi.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
