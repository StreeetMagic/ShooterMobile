using Characters.Enemies.Configs;
using UnityEngine;

namespace Characters.Enemies._components.TargetTriggers
{
  public class EnemyIdleTimer
  {
    private readonly EnemyConfig _config;

    private float _timeLeft;

    public EnemyIdleTimer(EnemyConfig config)
    {
      _config = config;
    }

    public bool IsDone => _timeLeft <= 0;

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;
    }

    public void Reset()
    {
      _timeLeft = _config.IdleDuration;
    }
  }
}