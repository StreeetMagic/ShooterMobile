using Configs.Resources.SoundConfigs;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.EnemyShooters
{
  public class EnemyShooter
  {
    private readonly PlayerProvider _playerProvider;
    private readonly ProjectileFactory _projectileFactory;
    private readonly AudioService _audioService;
    private readonly Transform _transform;

    public EnemyShooter(PlayerProvider playerProvider, IStaticDataService staticDataService,
      ProjectileFactory zenjectFactory, TickableManager tickableManager, BackpackStorage backpackStorage,
      ICoroutineRunner coroutineRunner,
      AudioService audioService, Transform transform)
    {
      _playerProvider = playerProvider;
      _projectileFactory = zenjectFactory;
      _audioService = audioService;
      _transform = transform;
    }

    private Transform PlayerTransform => _playerProvider.Player.transform;

    public void Shoot()
    {
      Vector3 directionToTarget = PlayerTransform.position - _transform.position;
      _projectileFactory.CreateEnemyProjectile(_transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}