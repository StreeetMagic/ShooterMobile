using System.Collections;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : ITickable, IInitializable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly ProjectileFactory _projectileFactory;
    private readonly TickableManager _tickableManager;
    private readonly BackpackStorage _backpackStorage;

    private CoroutineDecorator _coroutine;

    public PlayerShooter(
      PlayerProvider playerProvider, IStaticDataService staticDataService,
      ProjectileFactory zenjectFactory, TickableManager tickableManager, BackpackStorage backpackStorage)
    {
      _playerProvider = playerProvider;
      _staticDataService = staticDataService;
      _projectileFactory = zenjectFactory;
      _tickableManager = tickableManager;
      _backpackStorage = backpackStorage;
    }

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
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
      if (PlayerTargetHolder.HasTarget && _backpackStorage.IsFull == false)
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
        if (PlayerTargetHolder.HasTarget == false || _backpackStorage.IsFull)
        {
          StopShootingCoroutine();
          yield break; // Добавляем выход из корутины при выполнении условия
        }

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

      _projectileFactory.Create(Transform, transfromPosition, rotation);
    }
  }
}