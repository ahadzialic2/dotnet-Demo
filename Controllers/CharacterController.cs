using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_Demo.Models;
using dotnet_Demo.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    { 
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService) //injectamo characterServie u kontroler -> dependency injection
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        //set-ali smo rutu GetAll za metodu ispod
        //public IActionResult Get() { //povratni tip IActionResult nam omogucava da saljemo specificne http kodove klijentu zajedno
        // sa konkretnim podacima koji su requestovani
         public async Task<ActionResult<List<Character>>> Get() { //promijenjen povratni tip u ActionResult -> da se prikaze json schema na swaggeru
            return Ok(await _characterService.GetAllCharacters()); //saljemo kod 200 i nas mock karakter 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetSingle(int id) {
            return Ok(await _characterService.GetCharacterById(id)); //vrati default ako nema ni jedan da zadovoljana c.id == id(parametar)
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter) {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}