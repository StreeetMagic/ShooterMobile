using Gameplay.Weapons;
using PersistentProgresses;
using SaveLoadServices;
using StaticDataServices;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponId : IProgressWriter
  {
    public PlayerWeaponId(IStaticDataService staticDataService)
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