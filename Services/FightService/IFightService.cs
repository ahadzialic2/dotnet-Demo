using System.Threading.Tasks;
using dotnet_Demo.Dtos.Fight;
using dotnet_Demo.Models;

namespace dotnet_Demo.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);

    }
}
