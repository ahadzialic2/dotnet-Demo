using dotnet_Demo.Services.FightService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_Demo.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
    }
}
