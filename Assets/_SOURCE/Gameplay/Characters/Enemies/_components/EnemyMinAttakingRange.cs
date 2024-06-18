using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMaxAttakingRange
  {
    private readonly EnemyConfig _config;
    private readonly EnemyGrenadeThrower _grenadeThrower;

    public EnemyMaxAttakingRange(EnemyConfig config, EnemyGrenadeThrower grenadeThrower)
    {
      _config = config;
      _grenadeThrower = grenadeThrower;
    }

    public float Get()
    {
      float maxAttackingRange;

      List<float> distances = new();

      if (_config.IsShooter)
        distances.Add(_config.ShootRange);

      if (_config.IsGrenadeThrower)
        distances.Add(_config.GrenadeThrowRange);

      distances.Add(_config.MeleeRange);

      maxAttackingRange = distances.Max();

      return maxAttackingRange;
    }
  }
}