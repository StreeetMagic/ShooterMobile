using Gameplay.Characters.Players.MeshModels;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponSwitcher
  {
    private readonly PlayerWeaponContainer _weaponContainer;
    private readonly PlayerWeaponShootingPoint _shootingPoint;

    public PlayerWeaponSwitcher(PlayerWeaponContainer weaponContainer,
      PlayerWeaponShootingPoint shootingPoint, PlayerWeaponIdProvider playerWeaponIdProvider)
    {
      _weaponContainer = weaponContainer;
      _shootingPoint = shootingPoint;

      if (playerWeaponIdProvider.WeaponTypeId == WeaponTypeId.Unknown)
        throw new System.Exception("У игрока не указан айдишник оружия");

      DisableAll();
      NullShootingPoint();

      SwitchTo(playerWeaponIdProvider.WeaponTypeId);
    }

    public void SwitchTo(WeaponTypeId weaponTypeId)
    {
      GameObject weapon =
        _weaponContainer
          .Weapons
          .Find(x => x.WeaponTypeId == weaponTypeId)
          .GameObject;

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