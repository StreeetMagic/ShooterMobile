using Gameplay.Weapons;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using Loggers;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponIdProvider : IProgressWriter
  {
    private readonly PlayerWeaponStorage _playerWeaponStorage;
    private readonly DebugLogger _debugLogger;

    public PlayerWeaponIdProvider(ConfigService configService, PlayerWeaponStorage playerWeaponStorage,
      DebugLogger debugLogger)
    {
      _playerWeaponStorage = playerWeaponStorage;
      _debugLogger = debugLogger;

      PrevId = new ReactiveProperty<WeaponTypeId>(0);

      CurrentId = new ReactiveProperty<WeaponTypeId>
      {
        Value = configService.PlayerConfig.StartWeapons[0]
      };

      NextId = new ReactiveProperty<WeaponTypeId>(0);

      OnCurrentIdChanged(CurrentId.Value);

      CurrentId.ValueChanged += OnCurrentIdChanged;
    }

    private void OnCurrentIdChanged(WeaponTypeId currentId)
    {
      _debugLogger.LogPlayerWeapons(_playerWeaponStorage);

      int weapontCount = _playerWeaponStorage.Weapons.Value.Count;
      
      Debug.Log(weapontCount);

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

    public ReactiveProperty<WeaponTypeId> PrevId { get; }
    public ReactiveProperty<WeaponTypeId> CurrentId { get; }
    public ReactiveProperty<WeaponTypeId> NextId { get; }

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