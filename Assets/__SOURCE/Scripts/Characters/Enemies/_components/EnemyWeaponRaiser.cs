using Gameplay.Characters.Enemies.Configs;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyWeaponRaiser
  {
    private readonly EnemyConfig _config;

    private float _timeLeft;
    
    public EnemyWeaponRaiser(EnemyConfig config)
    {
      _config = config;
      Reset();
    }

    public bool IsDone => _timeLeft <= 0;

    public void Reset()
    {
      _timeLeft = _config.WeaponRisingTime;
    }

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;
    }
  }
}