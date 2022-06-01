using System.Threading.Tasks;
using dotnet_Demo.Dtos.Character;
using dotnet_Demo.Dtos.Weapon;
using dotnet_Demo.Models;

namespace dotnet_Demo.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
