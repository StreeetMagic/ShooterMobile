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
      Id = configService.PlayerConfig.StartWeapons[0];
    }

    public WeaponTypeId Id { get; set; }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Id = projectProgress.CurrentPlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      //projectProgress.CurrentPlayerWeaponId = WeaponTypeId;
    }
  }
}