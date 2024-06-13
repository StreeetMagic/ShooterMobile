using Gameplay.Weapons;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponIdProvider : IProgressWriter
  {
    public PlayerWeaponIdProvider(IStaticDataService staticDataService)
    {
      WeaponTypeId = staticDataService.GetPlayerConfig().StartWeapon;
    }

    public WeaponTypeId WeaponTypeId { get; set; }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      WeaponTypeId = projectProgress.PlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerWeaponId = WeaponTypeId;
    }
  }
}