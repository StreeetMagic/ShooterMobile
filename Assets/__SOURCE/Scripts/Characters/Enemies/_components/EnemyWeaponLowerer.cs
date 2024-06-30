using Characters.Enemies.Configs;
using UnityEngine;

namespace Characters.Enemies._components
{
  public class EnemyWeaponLowerer
  {
    private readonly EnemyConfig _config;

    private float _timeLeft;
    
    public EnemyWeaponLowerer(EnemyConfig config)
    {
      _config = config;
      Reset();
    }

    public bool IsDone => _timeLeft <= 0;

    public void Reset()
    {
      _timeLeft = _config.WeaponLoweringTime;
    }

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;
    }
  }
}