using AudioServices;
using Gameplay.Projectiles.Scripts;
using Sounds;
using UnityEngine;

namespace Gameplay.Characters.Enemies.EnemyShooters
{
  public class EnemyShooter
  {
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;

    public EnemyShooter(ProjectileFactory zenjectFactory,
      AudioService audioService)
    {
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
    }

    public void Shoot(Transform parentTransform, Vector3 startPosition, Vector3 directionToTarget, EnemyConfig enemyConfig)
    {
      _projectileFactory.CreateEnemyProjectile(parentTransform, startPosition, directionToTarget, enemyConfig);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}