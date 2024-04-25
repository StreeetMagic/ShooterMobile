using Configs.Resources.SoundConfigs.Scripts;
using Gameplay.Characters.Players._components.Projectiles.Scripts;
using Infrastructure.AudioServices;
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

    public void Shoot(Transform parentTransform, Vector3 startPosition, Vector3 directionToTarget)
    {
      _projectileFactory.CreateEnemyProjectile(parentTransform, startPosition, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}