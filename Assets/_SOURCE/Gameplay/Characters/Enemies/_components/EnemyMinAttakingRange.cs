using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMaxAttakingRange
  {
    private readonly float _maxAttackingRange;

    public EnemyMaxAttakingRange(EnemyConfig config)
    {
      EnemyConfig config1 = config;
      List<float> distances = new();

      if (config1.IsShooter)
        distances.Add(config1.ShootRange);

      if (config1.IsGrenadeThrower)
        distances.Add(config1.GrenadeThrowRange);

      distances.Add(config1.MeleeRange);

      _maxAttackingRange = distances.Max();
    }

    public float Get()
    {
      return _maxAttackingRange;
    }
  }
}