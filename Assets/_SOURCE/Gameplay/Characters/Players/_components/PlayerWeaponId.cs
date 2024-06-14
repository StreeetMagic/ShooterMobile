using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponIdProvider : IProgressWriter
  {
    public PlayerWeaponIdProvider(ConfigService configService)
    {
      WeaponTypeId = configService.PlayerConfig.StartWeapons[0];
    }

    public WeaponTypeId WeaponTypeId { get; set; }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      WeaponTypeId = projectProgress.CurrentPlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.CurrentPlayerWeaponId = WeaponTypeId;
    }
  }
}