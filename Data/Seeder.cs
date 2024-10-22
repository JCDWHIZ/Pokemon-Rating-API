// using System;
// using ProductsApi.Models;

// namespace ProductsApi.Data;

//  public class Seed
//     {
//         private readonly DataContext dataContext;
//         public Seed(DataContext context)
//         {
//             this.dataContext = context;
//         }
//         public void SeedDataContext()
//         {
//             if (!dataContext.PokemonOwners.Any())
//             {
//                 var pokemonOwners = new List<PokemonOwner>()
//                 {
//                     new PokemonOwner()
//                     {
//                         Pokemon = new Pokemon()
//                         {
//                             Name = "Pikachu",
//                             BirthDate = new DateTime(1903,1,1),
//                             PokemonCategories = new List<PokemonCategory>()
//                             {
//                                 new PokemonCategory { Category = new Category() { Name = "Electric"}}
//                             },
//                             Reviews = new List<Review>()
//                             {
//                                 new Review { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
//                                 new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
//                                 new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
//                                 Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
//                             }
//                         },
//                         Owner = new Owner()
//                         {
//                             FirstName = "Jack",
//                             LastName = "London",
//                             Gym = "Brocks Gym",
//                             Country = new Country()
//                             {
//                                 Name = "Kanto"
//                             }
//                         }
//                     },
//                     new PokemonOwner()
//                     {
//                         Pokemon = new Pokemon()
//                         {
//                             Name = "Squirtle",
//                             BirthDate = new DateTime(1903,1,1),
//                             PokemonCategories = new List<PokemonCategory>()
//                             {
//                                 new PokemonCategory { Category = new Category() { Name = "Water"}}
//                             },
//                             Reviews = new List<Review>()
//                             {
//                                 new Review { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
//                                 new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
//                                 new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
//                                 Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
//                             }
//                         },
//                         Owner = new Owner()
//                         {
//                             FirstName = "Harry",
//                             LastName = "Potter",
//                             Gym = "Mistys Gym",
//                             Country = new Country()
//                             {
//                                 Name = "Saffron City"
//                             }
//                         }
//                     },
//                                     new PokemonOwner()
//                     {
//                         Pokemon = new Pokemon()
//                         {
//                             Name = "Venasuar",
//                             BirthDate = new DateTime(1903,1,1),
//                             PokemonCategories = new List<PokemonCategory>()
//                             {
//                                 new PokemonCategory { Category = new Category() { Name = "Leaf"}}
//                             },
//                             Reviews = new List<Review>()
//                             {
//                                 new Review { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
//                                 new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
//                                 Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
//                                 new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
//                                 Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
//                             }
//                         },
//                         Owner = new Owner()
//                         {
//                             FirstName = "Ash",
//                             LastName = "Ketchum",
//                             Gym = "Ashs Gym",
//                             Country = new Country()
//                             {
//                                 Name = "Millet Town"
//                             }
//                         }
//                     }
//                 };
//                 dataContext.PokemonOwners.AddRange(pokemonOwners);
//                 dataContext.SaveChanges();
//             }
//         }
//     }


using System;
using System.Collections.Generic;
using System.Linq;
using ProductsApi.Models;

namespace ProductsApi.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            // Seed Categories if none exist
            if (!_context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category() { Name = "Electric" },
                    new Category() { Name = "Water" },
                    new Category() { Name = "Grass" },
                    new Category() { Name = "Fire" }
                };
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }

            // Seed Countries if none exist
            if (!_context.Countries.Any())
            {
                var countries = new List<Country>()
                {
                    new Country() { Name = "Kanto" },
                    new Country() { Name = "Johto" },
                    new Country() { Name = "Hoenn" }
                };
                _context.Countries.AddRange(countries);
                _context.SaveChanges();
            }

            // Seed Owners if none exist
            if (!_context.Owners.Any())
            {
                var owners = new List<Owner>()
                {
                    new Owner() { FirstName = "Ash", LastName = "Ketchum", Gym = "Pallet Town Gym", Country = _context.Countries.First(c => c.Name == "Kanto") },
                    new Owner() { FirstName = "Misty", LastName = "Williams", Gym = "Cerulean Gym", Country = _context.Countries.First(c => c.Name == "Kanto") },
                    new Owner() { FirstName = "Brock", LastName = "Stone", Gym = "Pewter Gym", Country = _context.Countries.First(c => c.Name == "Kanto") }
                };
                _context.Owners.AddRange(owners);
                _context.SaveChanges();
            }

            // Seed Pokemon if none exist
            if (!_context.Pokemon.Any())
            {
                var pikachu = new Pokemon()
                {
                    Name = "Pikachu",
                    BirthDate = new DateTime(1903, 1, 1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory { Category = _context.Categories.First(c => c.Name == "Electric") }
                    },
                    Reviews = new List<Review>()
                    {
                        new Review { Title = "Pikachu is awesome!", Text = "Pikachu is the best electric Pokemon.", Rating = 5, 
                        Reviewer = new Reviewer { FirstName = "John", LastName = "Doe" } }
                    }
                };

                var squirtle = new Pokemon()
                {
                    Name = "Squirtle",
                    BirthDate = new DateTime(1903, 1, 1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory { Category = _context.Categories.First(c => c.Name == "Water") }
                    },
                    Reviews = new List<Review>()
                    {
                        new Review { Title = "Squirtle rocks!", Text = "Squirtle is great for water-type battles.", Rating = 4, 
                        Reviewer = new Reviewer { FirstName = "Jane", LastName = "Smith" } }
                    }
                };

                _context.Pokemon.AddRange(pikachu, squirtle);
                _context.SaveChanges();
            }

            // Seed PokemonOwners if none exist
            if (!_context.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        Pokemon = _context.Pokemon.First(p => p.Name == "Pikachu"),
                        Owner = _context.Owners.First(o => o.FirstName == "Ash")
                    },
                    new PokemonOwner()
                    {
                        Pokemon = _context.Pokemon.First(p => p.Name == "Squirtle"),
                        Owner = _context.Owners.First(o => o.FirstName == "Misty")
                    }
                };
                _context.PokemonOwners.AddRange(pokemonOwners);
                _context.SaveChanges();
            }
        }
    }
}
