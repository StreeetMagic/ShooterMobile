using System.Collections;
using Gameplay.Characters.Players.PlayerFactories;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Infrastructure.GameLoop;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class Shooter : ITickable
  {
    private readonly TargetHolder _targetHolder;
    private readonly CoroutineDecorator _coroutine;
    private readonly PlayerFactory _playerFactory;
    private IAssetProvider _assetProvider;

    private Projectile Projectile => _assetProvider.Get<Projectile>();
    private Transform Transfrom => _playerFactory.Player.transform;

    public Shooter(TargetHolder targetHolder, GameLoopGameBootstrapper coroutineRunner, IAssetProvider assetProvider, PlayerFactory playerFactory)
    {
      _targetHolder = targetHolder;
      _assetProvider = assetProvider;
      _playerFactory = playerFactory;

      _coroutine = new CoroutineDecorator(coroutineRunner, Shooting);
    }

    public void Tick()
    {
      if (_targetHolder.HasTarget == false)
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
        var rotation = _targetHolder.DirectionToTarget;

        Object.Instantiate(Projectile, Transfrom.position, Quaternion.LookRotation(rotation));

        yield return new WaitForSeconds(.1f);
      }
    }
  }
}