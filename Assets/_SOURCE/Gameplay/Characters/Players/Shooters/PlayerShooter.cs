using System.Collections;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.GameLoop;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : ITickable
  {
    private readonly CoroutineDecorator _coroutine;
    private readonly IAssetProvider _assetProvider;
    private readonly PlayerProvider _playerProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly IZenjectFactory _zenjectFactory;

    public PlayerShooter(IAssetProvider assetProvider,
      PlayerProvider playerProvider, IStaticDataService staticDataService,
      IZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _playerProvider = playerProvider;
      _staticDataService = staticDataService;
      _zenjectFactory = zenjectFactory;

      MonoBehaviour coroutineRunner = Object.FindObjectOfType<GameLoopBootstrapper>();

      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Projectile Projectile => _assetProvider.Get<Projectile>();
    private Transform Transfrom => _playerProvider.Player.ShootingPoint;
    private PlayerAnimator PlayerAnimator => _playerProvider.PlayerAnimator;
    private PlayerAnimatorEventHandler PlayerAnimatorEventHandler => _playerProvider.PlayerAnimatorEventHandler;

    public void Subscribe()
    {
      //PlayerAnimatorEventHandler.Shot += Shoot;
    }

    public void Tick()
    {
      if (PlayerTargetHolder.HasTarget == false)
      {
        if (_coroutine.IsRunning)
          _coroutine.Stop();
      }
      else
      {
        if (_coroutine.IsRunning == false)
          _coroutine.Start();
      }
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
      Vector3 position = Transfrom.position;
      Vector3 transfromPosition = new(position.x, 1, position.z);

      _zenjectFactory.Instantiate(Projectile, transfromPosition, Quaternion.LookRotation(rotation));
    }
  }
}