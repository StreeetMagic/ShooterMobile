using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyWeaponReloader : MonoBehaviour
  {
    [Inject] private EnemyConfig _config;

    private int _bulletsInMagazine;

    private void Awake()
    {
      _bulletsInMagazine = _config.MagazineCapacity;
    }

    public bool IsEmpty => _bulletsInMagazine == 0;

    public void Reload()
    {
      _bulletsInMagazine = _config.MagazineCapacity;
    }

    public void SpendBullet()
    {
      _bulletsInMagazine--;
    }
  }
}