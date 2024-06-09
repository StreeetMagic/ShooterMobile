using Gameplay.Characters.Players;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeleeAttacker
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;

    public EnemyMeleeAttacker(PlayerProvider playerProvider, EnemyConfig config)
    {
      _playerProvider = playerProvider;
      _config = config;
    }

    public void Attack()
    {
      _playerProvider.Instance.Health.TakeDamage(_config.MeeleAttackDamage);
    }
  }
}