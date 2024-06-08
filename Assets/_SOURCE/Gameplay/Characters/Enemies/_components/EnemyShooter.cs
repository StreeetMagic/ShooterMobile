using AudioServices;
using Gameplay.Projectiles.Scripts;
using Sounds;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShooter
  {
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly EnemyWeaponReloader _reloader;

    public EnemyShooter(ProjectileFactory zenjectFactory,
      AudioService audioService, EnemyWeaponReloader reloader)
    {
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _reloader = reloader;
    }

    public void Shoot(Transform parentTransform, Vector3 startPosition, Vector3 directionToTarget, EnemyConfig enemyConfig)
    {
      _projectileFactory.CreateEnemyProjectile(parentTransform, startPosition, directionToTarget, enemyConfig);
      _audioService.PlaySound(SoundId.Shoot);
      _reloader.SpendBullet();
    }
  }
}