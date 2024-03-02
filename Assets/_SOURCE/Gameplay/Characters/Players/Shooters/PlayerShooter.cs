using System.Collections;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.GameLoop;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : ITickable
  {
    private readonly CoroutineDecorator _coroutine;
    private readonly IAssetProvider _assetProvider;
    private readonly PlayerProvider _playerProvider;
    
    private PlayerTargetHolder _playerTargetHolder;

    private Projectile Projectile => _assetProvider.Get<Projectile>();
    private Transform Transfrom => _playerProvider.Player.ShootingPoint;

    public PlayerShooter( GameLoopGameBootstrapper coroutineRunner,
      IAssetProvider assetProvider, PlayerProvider playerProvider)
    {

      _assetProvider = assetProvider;
      _playerProvider = playerProvider;

      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    public void Tick()
    {
      if (_playerTargetHolder.HasTarget == false)
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
        var rotation = _playerTargetHolder.DirectionToTarget;

        Vector3 transfromPosition = new Vector3(Transfrom.position.x, 1, Transfrom.position.z);

        Object.Instantiate(Projectile, transfromPosition, Quaternion.LookRotation(rotation));

        yield return new WaitForSeconds(.1f);
      }
    }
  }
}