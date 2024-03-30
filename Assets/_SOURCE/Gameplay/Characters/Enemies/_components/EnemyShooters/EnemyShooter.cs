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
    private readonly Enemy _enemy;

    public EnemyShooter(PlayerProvider playerProvider, ProjectileFactory zenjectFactory,
      AudioService audioService, Enemy enemy)
    {
      _playerProvider = playerProvider;
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _enemy = enemy;
    }

    private Transform PlayerTransform => _playerProvider.Player.transform;

    public void Shoot()
    {
      Vector3 directionToTarget = PlayerTransform.position - _enemy.transform.position;
      _projectileFactory.CreateEnemyProjectile(_enemy.transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}