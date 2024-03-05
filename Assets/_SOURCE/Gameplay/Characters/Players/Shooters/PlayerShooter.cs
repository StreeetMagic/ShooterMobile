using System.Collections;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.GameLoop;
using Infrastructure.AssetProviders;
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

    public PlayerShooter(IAssetProvider assetProvider, PlayerProvider playerProvider)
    {
      _assetProvider = assetProvider;
      _playerProvider = playerProvider;

      MonoBehaviour coroutineRunner = Object.FindObjectOfType<GameLoopBootstrapper>();

      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Projectile Projectile => _assetProvider.Get<Projectile>();
    private Transform Transfrom => _playerProvider.Player.ShootingPoint;

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
        var rotation = PlayerTargetHolder.DirectionToTarget;

        Vector3 transfromPosition = new Vector3(Transfrom.position.x, 1, Transfrom.position.z);

        Object.Instantiate(Projectile, transfromPosition, Quaternion.LookRotation(rotation));

        yield return new WaitForSeconds(.1f);
      }
    }
  }
}