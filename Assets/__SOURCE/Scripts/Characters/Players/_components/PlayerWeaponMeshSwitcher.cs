using Characters.Players._components.MeshModels;
using UnityEngine;
using Weapons;

namespace Characters.Players._components
{
  public class PlayerWeaponMeshSwitcher
  {
    private readonly PlayerWeaponContainer _weaponContainer;
    private readonly PlayerWeaponShootingPoint _shootingPoint;

    public PlayerWeaponMeshSwitcher(PlayerWeaponContainer weaponContainer,
      PlayerWeaponShootingPoint shootingPoint, PlayerWeaponIdProvider playerWeaponIdProvider)
    {
      _weaponContainer = weaponContainer;
      _shootingPoint = shootingPoint;

      if (playerWeaponIdProvider.CurrentId.Value == WeaponTypeId.Unknown)
        throw new System.Exception("У игрока не указан айдишник оружия");

      DisableAll();
      NullShootingPoint();

      SwitchTo(playerWeaponIdProvider.CurrentId.Value);
      
      playerWeaponIdProvider.CurrentId.ValueChanged += SwitchTo;
    }

    private void SwitchTo(WeaponTypeId weaponTypeId)
    {
      GameObject weapon =
        _weaponContainer
          .Weapons
          .Find(x => x.WeaponTypeId == weaponTypeId)
          .GameObject;

      DisableAll();
      NullShootingPoint();

      EnableGameObject(weapon);
      SetShootingPoint(weaponTypeId);
    }

    private void DisableAll()
    {
      foreach (WeaponSetup weapon in _weaponContainer.Weapons)
        DisableGameObject(weapon.GameObject);
    }

    private void DisableGameObject(GameObject weapon) =>
      weapon.SetActive(false);

    private void EnableGameObject(GameObject weapon) =>
      weapon.SetActive(true);

    private void NullShootingPoint() =>
      _shootingPoint.Transform = null;

    private void SetShootingPoint(WeaponTypeId weaponTypeId) =>
      _shootingPoint.Transform = _weaponContainer
        .Weapons
        .Find(x => x.WeaponTypeId == weaponTypeId)
        .ShootingPoint;
  }
}