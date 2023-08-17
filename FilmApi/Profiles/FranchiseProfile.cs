using AutoMapper;
using FilmApi.DTOs.Franchise;
using FilmApi.Models;

namespace FilmApi.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, ReadFranchiseDto>().ReverseMap();
            CreateMap<Franchise, CreateFranchiseDto>().ReverseMap();
            CreateMap<Franchise, UpdateFranchiseDto>().ReverseMap();
        }
    }
}

