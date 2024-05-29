using Gameplay.Characters.Players;
using Gameplay.Weapons;
using UnityEngine;
using Zenject;

public class WeaponSwitcher : MonoBehaviour
{
  [Inject] private Weapon _weapon;
  [Inject] private WeaponContainer _weaponContainer;
  [Inject] private WeaponShootingPoint _shootingPoint;

  private void Start()
  {
    DisableAll();
    NullShootingPoint();

    SwitchTo(_weapon.Current);
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