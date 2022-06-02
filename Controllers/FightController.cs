using System.Threading.Tasks;
using dotnet_Demo.Dtos.Fight;
using dotnet_Demo.Models;
using dotnet_Demo.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        [HttpPost("Weapon")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponAttack(request));
        }
        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<AttackResultDto>>> SkillAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }
        [HttpPost]//default call ovog kotrolera
        public async Task<ActionResult<ServiceResponse<FightResultDto>>> Fight(FightRequestDto request)
        {
            return Ok(await _fightService.Fight(request));
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<HighscoreDto>>> GetHighScore()
        {
            return Ok(await _fightService.GetHighscore());
        }
    }
}
