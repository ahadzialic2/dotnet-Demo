using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_Demo.Models;

namespace dotnet_Demo.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<List<Character>> AddCharacter(Character newCharacter);
    }
}