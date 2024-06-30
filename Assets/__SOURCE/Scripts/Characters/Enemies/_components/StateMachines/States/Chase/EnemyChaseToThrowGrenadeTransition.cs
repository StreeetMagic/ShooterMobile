using Characters.Enemies._components.StateMachines.States.ThrowGrenade;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Characters.Players;
using Infrastructure.RandomServices;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.Chase
{
  public class EnemyChaseToThrowGrenadeTransition : Transition
  {
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyConfig _config;
    private readonly EnemyGrenadeStorage _grenadeStorage;
    private readonly EnemyGrenadeThrowTimer _grenadeThrowTimer;
    private readonly RandomService _randomService;

    private float _randomThrowDelayLeft;

    public EnemyChaseToThrowGrenadeTransition(PlayerProvider playerProvider, EnemyConfig config,
      EnemyGrenadeStorage grenadeStorage, EnemyGrenadeThrowTimer grenadeThrowTimer, RandomService randomService)
    {
      _playerProvider = playerProvider;
      _config = config;
      _grenadeStorage = grenadeStorage;
      _grenadeThrowTimer = grenadeThrowTimer;
      _randomService = randomService;
    }

    public override void Tick()
    {
      if (_config.IsGrenadeThrower == false)
        return;

      if (_grenadeStorage.HasGrenades == false)
        return;

      if (TargetIsStandsOnSamePosition() == false)
      {
        _randomThrowDelayLeft = _randomService.GetRandomFloat(_config.GrenadeThrowRandomDelay);
        
        return;
      }

      if (_grenadeThrowTimer.IsUp == false)
      {
        return;
      }

      if (_randomThrowDelayLeft > 0)
      {
        _randomThrowDelayLeft -= Time.deltaTime;
        return;
      }

      Enter<EnemyThrowGrenadeState>();
    }

    private bool TargetIsStandsOnSamePosition() =>
      _playerProvider.Instance.StandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime;
  }
}