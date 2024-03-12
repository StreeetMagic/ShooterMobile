using System;
using System.Collections;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : ITickable, IInitializable
  {
    private readonly IAssetProvider _assetProvider;
    private readonly PlayerProvider _playerProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly IZenjectFactory _zenjectFactory;
    private readonly TickableManager _tickableManager;

    private CoroutineDecorator _coroutine;

    public PlayerShooter(IAssetProvider assetProvider,
      PlayerProvider playerProvider, IStaticDataService staticDataService,
      IZenjectFactory zenjectFactory, TickableManager tickableManager)
    {
      _assetProvider = assetProvider;
      _playerProvider = playerProvider;
      _staticDataService = staticDataService;
      _zenjectFactory = zenjectFactory;
      _tickableManager = tickableManager;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Projectile Projectile => _assetProvider.Get<Projectile>();
    private Transform Transform => _playerProvider.Player.ShootingPoint;
    private PlayerAnimator PlayerAnimator => _playerProvider.PlayerAnimator;
    private PlayerAnimatorEventHandler PlayerAnimatorEventHandler => _playerProvider.PlayerAnimatorEventHandler;

    public void Initialize()
    {
      _tickableManager.Add(this);
      MonoBehaviour coroutineRunner = Object.FindObjectOfType<SceneContext>();
      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    public void Tick()
    {
      if (PlayerTargetHolder.HasTarget)
        StartShootingCoroutine();
      else
        StopShootingCoroutine();
    }

    public void Subscribe()
    {
      //PlayerAnimatorEventHandler.Shot += Shoot;
    }

    private void StopShootingCoroutine()
    {
      if (_coroutine.IsRunning)
        _coroutine.Stop();
    }

    private void StartShootingCoroutine()
    {
      if (_coroutine.IsRunning == false)
        _coroutine.Start();
    }

    private IEnumerator Shooting()
    {
      while (true)
      {
        Shoot();

        //PlayerAnimator.Shoot();

        int fireRate =
          _staticDataService
            .ForPlayer()
            .FireRate;

        float coolDown = 1f / fireRate;

        yield return new WaitForSeconds(coolDown);
      }
    }

    private void Shoot()
    {
      Vector3 rotation = PlayerTargetHolder.DirectionToTarget;
      Vector3 position = Transform.position;
      Vector3 transfromPosition = new(position.x, 1, position.z);

      _zenjectFactory.Instantiate(Projectile, transfromPosition, Quaternion.LookRotation(rotation));
    }
  }
}