using System;
using AutoMapper;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        CreateMap<CountryDto, Country>();
        CreateMap<OwnerDto, Owner>();
        CreateMap<PokemonDto, Pokemon>();
        CreateMap<ReviewDto, Review>();
        CreateMap<ReviewerDto, Reviewer>();
        CreateMap<Country, CountryDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Reviewer, ReviewerDto>();
    }
}
