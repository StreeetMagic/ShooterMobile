using System.Collections.Generic;
using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponIdProvider : IProgressWriter
  {
    private readonly PlayerWeaponStorage _playerWeaponStorage;

    public PlayerWeaponIdProvider(ConfigService configService, PlayerWeaponStorage playerWeaponStorage)
    {
      _playerWeaponStorage = playerWeaponStorage;

      PrevId = new ReactiveProperty<WeaponTypeId>(0);

      CurrentId = new ReactiveProperty<WeaponTypeId>
      {
        Value = configService.PlayerConfig.StartWeapons[0]
      };

      NextId = new ReactiveProperty<WeaponTypeId>(0);

      OnCurrentIdChanged(CurrentId.Value);

      CurrentId.ValueChanged += OnCurrentIdChanged;
      
      _playerWeaponStorage.Weapons.Changed += OnWeaponsChanged;
    }

    private void OnWeaponsChanged(List<WeaponTypeId> weapons)
    {
      OnCurrentIdChanged(CurrentId.Value); 
    }

    public ReactiveProperty<WeaponTypeId> PrevId { get; }
    public ReactiveProperty<WeaponTypeId> CurrentId { get; }
    public ReactiveProperty<WeaponTypeId> NextId { get; }

    private void OnCurrentIdChanged(WeaponTypeId currentId)
    {
      int weapontCount = _playerWeaponStorage.Weapons.Value.Count;

      int currentIdIndex = _playerWeaponStorage.Weapons.IndexOf(currentId);

      if (currentIdIndex == 0)
        PrevId.Value = WeaponTypeId.Unknown;

      if (currentIdIndex == weapontCount - 1)
        NextId.Value = WeaponTypeId.Unknown;

      if (currentIdIndex > 0)
        PrevId.Value = _playerWeaponStorage.Weapons.Value[currentIdIndex - 1];

      if (currentIdIndex < weapontCount - 1)
        NextId.Value = _playerWeaponStorage.Weapons.Value[currentIdIndex + 1];
    }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      CurrentId.Value = projectProgress.CurrentPlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      //projectProgress.CurrentPlayerWeaponId = WeaponTypeId;
    }
  }
}