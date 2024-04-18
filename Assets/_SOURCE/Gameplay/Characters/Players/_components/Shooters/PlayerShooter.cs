using System.Collections;
using Configs.Resources.SoundConfigs;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AudioServices;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : MonoBehaviour
  {
    private PlayerProvider _playerProvider;
    private IStaticDataService _staticDataService;
    private ProjectileFactory _projectileFactory;
    private BackpackStorage _backpackStorage;
    private AudioService _audioService;

    private float _timeLeft;

    [Inject]
    public void Construct(
      PlayerProvider playerProvider, IStaticDataService staticDataService,
      ProjectileFactory zenjectFactory, BackpackStorage backpackStorage,
      AudioService audioService)
    {
      _playerProvider = playerProvider;
      _staticDataService = staticDataService;
      _projectileFactory = zenjectFactory;
      _backpackStorage = backpackStorage;

      _audioService = audioService;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Transform Transform => _playerProvider.Player.ShootingPoint;
    private float Cooldown => 1 / _staticDataService.GetPlayerConfig().FireRate;

    public void Update()
    {
      if (_backpackStorage.IsFull)
      {
        return;
      }

      if (PlayerTargetHolder.HasTarget)
      {
        Shooting();
      }
    }

    private void Shooting()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      Shoot();

      _timeLeft = Cooldown;
    }

    private void Shoot()
    {
      Vector3 directionToTarget = PlayerTargetHolder.DirectionToTarget;
      _projectileFactory.CreatePlayerProjectile(Transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}