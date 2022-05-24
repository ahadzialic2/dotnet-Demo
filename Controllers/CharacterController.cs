using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    { 
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id=1,Name = "Sam" }
        };

        [HttpGet("GetAll")]
        //set-ali smo rutu GetAll za metodu ispod
        //public IActionResult Get() { //povratni tip IActionResult nam omogucava da saljemo specificne http kodove klijentu zajedno
        // sa konkretnim podacima koji su requestovani
         public ActionResult<List<Character>> Get() { //promijenjen povratni tip u ActionResult -> da se prikaze json schema na swaggeru
            return Ok(characters); //saljemo kod 200 i nas mock karakter 
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id) {
            return Ok(characters.FirstOrDefault(c => c.Id == id)); //vrati default ako nema ni jedan da zadovoljana c.id == id(parametar)
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter) {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}