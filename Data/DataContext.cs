using System;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data;

public class DataContext:DbContext
{
public DataContext(DbContextOptions<DataContext> options): base(options){

}

public DbSet<Category> Categories { get; set; }
public DbSet<Country> Countries {get; set;}
public DbSet<Owner> Owners {get; set;}
public DbSet<Pokemon> Pokemon {get; set;}
public DbSet<PokemonCategory> PokemonCategories {get; set;}
public DbSet<PokemonOwner> PokemonOwners {get; set;}
public DbSet<Review> Reviews {get; set;}
public DbSet<Reviewer> Reviewers {get; set;}

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                    .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                    .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(c => c.OwnerId);





               // Seed Categories
    modelBuilder.Entity<Category>().HasData(
        new { Id = 1, Name = "Electric" },
        new { Id = 2, Name = "Water" },
        new { Id = 3, Name = "Grass" }
    );

    // Seed Countries
    modelBuilder.Entity<Country>().HasData(
        new { Id = 1, Name = "Kanto" },
        new { Id = 2, Name = "Saffron City" },
        new { Id = 3, Name = "Pallet Town" }
    );

    // Seed Owners
    modelBuilder.Entity<Owner>().HasData(
        new { Id = 1, FirstName = "Jack", LastName = "London", Gym = "Brock's Gym", CountryId = 1 },
        new { Id = 2, FirstName = "Harry", LastName = "Potter", Gym = "Misty's Gym", CountryId = 2 },
        new { Id = 3, FirstName = "Ash", LastName = "Ketchum", Gym = "Ash's Gym", CountryId = 3 }
    );

    // Seed Pokemon
    modelBuilder.Entity<Pokemon>().HasData(
        new { Id = 1, Name = "Pikachu", BirthDate = new DateTime(1903, 1, 1) },
        new { Id = 2, Name = "Squirtle", BirthDate = new DateTime(1903, 1, 1) },
        new { Id = 3, Name = "Venusaur", BirthDate = new DateTime(1903, 1, 1) }
    );

    // Seed PokemonCategory (relationship between Pokemon and Category)
    modelBuilder.Entity<PokemonCategory>().HasData(
        new { PokemonId = 1, CategoryId = 1 }, // Pikachu is Electric
        new { PokemonId = 2, CategoryId = 2 }, // Squirtle is Water
        new { PokemonId = 3, CategoryId = 3 }  // Venusaur is Grass
    );

    // Seed Reviews
    modelBuilder.Entity<Review>().HasData(
        new { Id = 1, Title = "Pikachu", Text = "Pikachu is the best pokemon, because it is electric", Rating = 5, PokemonId = 1, ReviewerId = 1 },
        new { Id = 2, Title = "Squirtle", Text = "Squirtle is the best water-type pokemon", Rating = 5, PokemonId = 2, ReviewerId = 2 },
        new { Id = 3, Title = "Venusaur", Text = "Venusaur is the best grass-type pokemon", Rating = 5, PokemonId = 3, ReviewerId = 3 }
    );

    // Seed Reviewers
    modelBuilder.Entity<Reviewer>().HasData(
        new { Id = 1, FirstName = "Teddy", LastName = "Smith" },
        new { Id = 2, FirstName = "Taylor", LastName = "Jones" },
        new { Id = 3, FirstName = "Jessica", LastName = "McGregor" }
    );

    // Seed PokemonOwner (relationship between Pokemon and Owner)
    modelBuilder.Entity<PokemonOwner>().HasData(
        new { PokemonId = 1, OwnerId = 1 }, // Pikachu belongs to Jack London
        new { PokemonId = 2, OwnerId = 2 }, // Squirtle belongs to Harry Potter
        new { PokemonId = 3, OwnerId = 3 }  // Venusaur belongs to Ash Ketchum
    );
        }
}
