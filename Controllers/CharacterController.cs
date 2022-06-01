using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_Demo.Dtos.Character;
using dotnet_Demo.Models;
using dotnet_Demo.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_Demo.Controllers
{
    [Authorize] //od sada iskljucivo autorizovani mogu pristupiti metodama ovog kontrolera
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    { 
       
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService) //injectamo characterServie u kontroler -> dependency injection
        {
            _characterService = characterService;
        }
        //[AllowAnonymous]
        [HttpGet("GetAll")]
        //set-ali smo rutu GetAll za metodu ispod
        //public IActionResult Get() { //povratni tip IActionResult nam omogucava da saljemo specificne http kodove klijentu zajedno
        // sa konkretnim podacima koji su requestovani
         public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get() { //promijenjen povratni tip u ActionResult -> da se prikaze json schema na swaggeru
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _characterService.GetAllCharacters()); //saljemo kod 200 i nas mock karakter 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id) {
            return Ok(await _characterService.GetCharacterById(id)); //vrati default ako nema ni jedan da zadovoljana c.id == id(parametar)
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter) {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }
        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }
    }
}