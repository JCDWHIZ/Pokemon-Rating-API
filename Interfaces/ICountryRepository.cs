using System;
using ProductsApi.Models;

namespace ProductsApi.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountry(int id);
    Country GetCountryByOwner(int ownerId);
    ICollection<Owner> GetOwnersFromAcountry(int CountryId);
    bool CountryExists(int id);
    bool CreateCountry(Country country);
    bool UpdateCountry(Country country);
    bool DeleteCountry(Country country);
    bool Save();
}
