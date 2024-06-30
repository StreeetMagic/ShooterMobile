using Characters.Enemies.Configs;
using UnityEngine;

namespace Characters.Enemies._components
{
  public class EnemyWeaponMagazineReloaderTimer
  {
    private readonly EnemyConfig _config;

    private float _timeLeft;

    public EnemyWeaponMagazineReloaderTimer(EnemyConfig config)
    {
      _config = config;
      Reset();
    }

    public bool IsDone => _timeLeft <= 0;

    public void Reset()
    {
      _timeLeft = _config.MagazineReloadTime;
    }

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;
    }
  }
}