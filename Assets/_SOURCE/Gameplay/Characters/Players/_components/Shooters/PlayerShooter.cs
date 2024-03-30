using System.Collections;
using Configs.Resources.SoundConfigs;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : ITickable, IInitializable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly ProjectileFactory _projectileFactory;
    private readonly TickableManager _tickableManager;
    private readonly BackpackStorage _backpackStorage;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly AudioService _audioService;

    private CoroutineDecorator _coroutine;

    public PlayerShooter(
      PlayerProvider playerProvider, IStaticDataService staticDataService,
      ProjectileFactory zenjectFactory, TickableManager tickableManager, BackpackStorage backpackStorage, ICoroutineRunner coroutineRunner,
      AudioService audioService)
    {
      _playerProvider = playerProvider;
      _staticDataService = staticDataService;
      _projectileFactory = zenjectFactory;
      _tickableManager = tickableManager;
      _backpackStorage = backpackStorage;
      _coroutineRunner = coroutineRunner;
      _audioService = audioService;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Transform Transform => _playerProvider.Player.ShootingPoint;
    private PlayerAnimator PlayerAnimator => _playerProvider.PlayerAnimator;
    private PlayerAnimatorEventHandler PlayerAnimatorEventHandler => _playerProvider.PlayerAnimatorEventHandler;
    private Transform ShootingPoint => _playerProvider.Player.ShootingPoint;

    public void Initialize()
    {
      _tickableManager.Add(this);

      _coroutine = new CoroutineDecorator(_coroutineRunner, Shooting);
    }

    public void Tick()
    {
      // if (PlayerTargetHolder.HasTarget && _backpackStorage.IsFull == false)
      //   StartShootingCoroutine();
      // else
      //   StopShootingCoroutine();

      if (_backpackStorage.IsFull)
      {
        StopShootingCoroutine();
        return;
      }

      if (PlayerTargetHolder.HasTarget)
      {
        StartShootingCoroutine();
      }
      else if (PlayerTargetHolder.HasTarget == false)
      {
        StopShootingCoroutine();
      }
    }

    public void Subscribe()
    {
      //PlayerAnimatorEventHandler.Shot += Shoot;
    }

    private void StartShootingCoroutine()
    {
      if (_coroutine.IsRunning == false)
      {
        Debug.Log("StartShootingCoroutine");

        _coroutine.Start();
      }
    }

    private void StopShootingCoroutine()
    {
      if (_coroutine.IsRunning)
      {
        Debug.Log("StopShootingCoroutine");
        _coroutine.Stop();
      }
    }

    private IEnumerator Shooting()
    {
      while (PlayerTargetHolder.HasTarget && _backpackStorage.IsFull == false)
      {
        Shoot();

        int fireRate =
          _staticDataService
            .GetPlayerConfig()
            .FireRate;

        float coolDown = 1f / fireRate;

        yield return new WaitForSeconds(coolDown);
      }
    }

    private void Shoot()
    {
      Vector3 directionToTarget = PlayerTargetHolder.DirectionToTarget;
      _projectileFactory.CreatePlayerProjectile(Transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}