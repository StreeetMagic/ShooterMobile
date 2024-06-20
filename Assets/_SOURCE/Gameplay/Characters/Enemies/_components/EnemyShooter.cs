using Gameplay.Characters.Enemies.Configs;
using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShooter
  {
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly EnemyConfig _enemyConfig;

    public EnemyShooter(ProjectileFactory zenjectFactory,
      AudioService audioService, EnemyConfig enemyConfig)
    {
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _enemyConfig = enemyConfig;
    }

    public void Shoot(Transform parent, Vector3 startPosition,
      Vector3 directionToTarget, EnemyConfig enemyConfig)
    {
      for (int i = 0; i < enemyConfig.BulletsPerShot; i++)
      {
        Vector3 angledDirection = AngleChanger.AddAngle(directionToTarget, _enemyConfig.BulletSpreadAngle);
        _projectileFactory.CreateEnemyProjectile(parent, startPosition, angledDirection, enemyConfig);
      }

      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}