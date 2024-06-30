using System.Collections.Generic;
using Infrastructure.ConfigProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using Weapons;

namespace Characters.Players._components
{
  public class PlayerWeaponIdProvider : IProgressWriter
  {
    private readonly WeaponStorage _weaponStorage;

    public PlayerWeaponIdProvider(ConfigProvider configProvider, WeaponStorage weaponStorage)
    {
      _weaponStorage = weaponStorage;

      PrevId = new ReactiveProperty<WeaponTypeId>(0);

      CurrentId = new ReactiveProperty<WeaponTypeId>
      {
        Value = configProvider.PlayerConfig.StartWeapons[0]
      };

      NextId = new ReactiveProperty<WeaponTypeId>(0);

      OnCurrentIdChanged(CurrentId.Value);

      CurrentId.ValueChanged += OnCurrentIdChanged;
      
      _weaponStorage.Weapons.Changed += OnWeaponsChanged;
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
      int weapontCount = _weaponStorage.Weapons.Value.Count;

      int currentIdIndex = _weaponStorage.Weapons.IndexOf(currentId);

      if (currentIdIndex == 0)
        PrevId.Value = WeaponTypeId.Unknown;

      if (currentIdIndex == weapontCount - 1)
        NextId.Value = WeaponTypeId.Unknown;

      if (currentIdIndex > 0)
        PrevId.Value = _weaponStorage.Weapons.Value[currentIdIndex - 1];

      if (currentIdIndex < weapontCount - 1)
        NextId.Value = _weaponStorage.Weapons.Value[currentIdIndex + 1];
    }

    public void ReadProgress(ProjectProgress projectProgress)
    {
      CurrentId.Value = projectProgress.CurrentPlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.CurrentPlayerWeaponId = CurrentId.Value; 
    }
  }
}