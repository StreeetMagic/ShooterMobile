using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeleeAttacker : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private EnemyConfig _config;

    public void Attack()
    {
      _playerProvider.PlayerHealth.TakeDamage(_config.MeeleAttackDamage);
    }
  }
}