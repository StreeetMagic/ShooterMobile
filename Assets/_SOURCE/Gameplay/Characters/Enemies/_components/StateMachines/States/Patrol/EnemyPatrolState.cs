using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Patrol
{
  public class EnemyPatrolState : State
  {    
    private const float DistanceToRoutePoint = 0.5f;

    private readonly EnemyMover _mover;
    private readonly EnemyRoutePointsManager _enemyRoutePointsManager;
    private readonly EnemyReturnToSpawnStatus _returnToSpawnStatus;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;
    private readonly HitStatus _hitStatus;
    
    public EnemyPatrolState(List<Transition> transitions, EnemyMover mover,
      EnemyRoutePointsManager enemyRoutePointsManager, EnemyReturnToSpawnStatus returnToSpawnStatus, 
      EnemyAnimatorProvider animatorProvider, EnemyConfig config, Enemy enemy, HitStatus hitStatus) 
      : base(transitions)
    {
      _mover = mover;
      _enemyRoutePointsManager = enemyRoutePointsManager;
      _returnToSpawnStatus = returnToSpawnStatus;
      _animatorProvider = animatorProvider;
      _config = config;
      _enemy = enemy;
      _hitStatus = hitStatus;
    }

    public override void Enter()
    {
    }

    public override void Tick()
    {
      base.Tick();
      
      _mover.Move(_enemyRoutePointsManager.NextRoutePointTransform.position, GetMoveSpeed());

      float distance = Vector3.Distance(_enemyRoutePointsManager.NextRoutePointTransform.position, _enemy.transform.position);

      if (distance < DistanceToRoutePoint)
      {
        _enemyRoutePointsManager.SetRandomRoute();
        _returnToSpawnStatus.IsReturn = false;
        _hitStatus.Disable();
      }
    }

    public override void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopWalkAnimation();
      _animatorProvider.Instance.StopRunAnimation();
    }
    
    private float GetMoveSpeed()
    {
      if (_returnToSpawnStatus.IsReturn)
      {
        _animatorProvider.Instance.PlayRunAnimation();
        return _config.RunSpeed;
      }
      else
      {
        _animatorProvider.Instance.PlayWalkAnimation();
        return _config.MoveSpeed;
      }
    }
  }
}