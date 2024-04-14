using Configs.Resources.SoundConfigs;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AudioServices;
using UnityEngine;

namespace Gameplay.Characters.Enemies.EnemyShooters
{
  public class EnemyShooter
  {
    private readonly PlayerProvider _playerProvider;
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;

    public EnemyShooter(PlayerProvider playerProvider, ProjectileFactory zenjectFactory,
      AudioService audioService)
    {
      _playerProvider = playerProvider;
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