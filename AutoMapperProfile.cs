using AutoMapper;
using dotnet_Demo.Dtos.Character;
using dotnet_Demo.Dtos.Fight;
using dotnet_Demo.Dtos.Skill;
using dotnet_Demo.Dtos.Weapon;
using dotnet_Demo.Models;

namespace dotnet_Demo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighscoreDto>();
        }
    }
}
