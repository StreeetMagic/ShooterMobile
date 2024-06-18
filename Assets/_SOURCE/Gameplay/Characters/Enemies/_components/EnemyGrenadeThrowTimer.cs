using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyGrenadeThrowTimer : ITickable
  {
    private readonly EnemyConfig _config;
    private float _timeLeft;

    public EnemyGrenadeThrowTimer(EnemyConfig config)
    {
      _config = config;
    }

    public bool IsUp => _timeLeft < 0;

    public void Reset()
    {
      _timeLeft = _config.GrenadeThrowCooldown; 
    }

    public void Tick()
    {
       _timeLeft -= Time.deltaTime;
    }
  }
}