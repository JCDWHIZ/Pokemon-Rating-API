using System;
using AutoMapper;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Models;

namespace ProductsApi.Repository;

public class OwnerRepository(DataContext context) : IOwnerRepository
{
    private readonly DataContext _context = context;

    public bool CreateOwner(Owner owner)
    {
        _context.Owners.Add(owner);
        return Save();
    }

    public Owner GetOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _context
            .PokemonOwners.Where(po => po.Pokemon.Id == pokeId)
            .Select(o => o.Owner)
            .ToList();
    }

    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public bool DeleteOwner(Owner owner)
    {
        _context.Remove(owner);
        return Save();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context
            .PokemonOwners.Where(p => p.Pokemon.Id == ownerId)
            .Select(o => o.Pokemon)
            .ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return _context.Owners.Any(o => o.Id == ownerId);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateOwner(Owner owner)
    {
        _context.Update(owner);
        return Save();
    }
}
