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
    private readonly EnemyWeaponReloader _reloader;
    private readonly EnemyConfig _enemyConfig;

    public EnemyShooter(ProjectileFactory zenjectFactory,
      AudioService audioService, EnemyWeaponReloader reloader, EnemyConfig enemyConfig)
    {
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _reloader = reloader;
      _enemyConfig = enemyConfig;
    }

    public void Shoot(Transform parentTransform, Vector3 startPosition, Vector3 directionToTarget, EnemyConfig enemyConfig)
    {
      for (int i = 0; i < enemyConfig.BulletsPerShot; i++)
      {
        Vector3 angledDirection = AngleChanger.AddAngle(directionToTarget, _enemyConfig.BulletSpreadAngle);
        _projectileFactory.CreateEnemyProjectile(parentTransform, startPosition, angledDirection, enemyConfig);
      }

      _audioService.PlaySound(SoundId.Shoot);
      _reloader.SpendBullet();
    }
  }
}