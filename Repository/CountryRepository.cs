using System;
using AutoMapper;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Models;

namespace ProductsApi.Repository;

public class CountryRepository(DataContext context, IMapper mapper) : ICountryRepository
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public bool CountryExists(int id)
    {
        return _context.Countries.Any(c => c.Id == id);
    }

    public bool CreateCountry(Country country)
    {
        _context.Add(country);
        return Save();
    }

    public ICollection<Country> GetCountries()
    {
        return _context.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFromAcountry(int CountryId)
    {
        return _context.Owners.Where(c => c.Country.Id == CountryId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateCountry(Country country)
    {
        _context.Update(country);
        return Save();
    }

    public bool DeleteCountry(Country country)
    {
        _context.Remove(country);
        return Save();
    }
}
