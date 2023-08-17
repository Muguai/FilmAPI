using AutoMapper;
using FilmApi.DTOs.Character;
using FilmApi.Models;

namespace FilmApi.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, ReadCharacterDto>().ReverseMap();
            CreateMap<Character, CreateCharacterDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();
        }
    }
}

