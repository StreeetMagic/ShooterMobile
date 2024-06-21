using Gameplay.Characters.Enemies.Configs;
using Gameplay.Projectiles.Scripts;
using Gameplay.Utilities;
using Infrastructure.ArtConfigServices;
using Infrastructure.AudioServices;
using Infrastructure.AudioServices.Sounds;
using Infrastructure.VisualEffects;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShooter
  {
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly EnemyConfig _enemyConfig;
    private readonly VisualEffectFactory _visualEffectFactory;
    private readonly ArtConfigProvider _artConfigProvider;

    public EnemyShooter(ProjectileFactory zenjectFactory, AudioService audioService, 
      EnemyConfig enemyConfig, VisualEffectFactory visualEffectFactory,
      ArtConfigProvider artConfigProvider)
    {
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _enemyConfig = enemyConfig;
      _visualEffectFactory = visualEffectFactory;
      _artConfigProvider = artConfigProvider;
    }

    public void Shoot(Transform parent, Vector3 startPosition,
      Vector3 directionToTarget, EnemyConfig enemyConfig)
    {
      for (int i = 0; i < enemyConfig.BulletsPerShot; i++)
      {
        Vector3 angledDirection = AngleChanger.AddAngle(directionToTarget, _enemyConfig.BulletSpreadAngle);
        _projectileFactory.CreateEnemyProjectile(parent, startPosition, angledDirection, enemyConfig);
      }

      _visualEffectFactory.CreateAndDestroy(_artConfigProvider.GetEnemyMuzzleFlashEffectId(enemyConfig.Id), startPosition, parent.rotation);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}