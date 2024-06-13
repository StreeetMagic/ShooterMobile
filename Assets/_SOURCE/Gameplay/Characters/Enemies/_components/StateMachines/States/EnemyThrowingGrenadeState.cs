using Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyThrowingGrenadeState : IState, ITickable
  {
    private readonly EnemyGrenadeThrower _grenadeThrower;
    private readonly EnemyStateMachine _stateMachine;
    private readonly EnemyToPlayerRotator _toPlayerRotator;

    private float _randomGrenadeDelayLeft;

    public EnemyThrowingGrenadeState(EnemyGrenadeThrower grenadeThrower,
      EnemyStateMachine stateMachine, EnemyToPlayerRotator toPlayerRotator)
    {
      _grenadeThrower = grenadeThrower;
      _stateMachine = stateMachine;
      _toPlayerRotator = toPlayerRotator;
    }

    public void Enter()
    {
      _randomGrenadeDelayLeft = _grenadeThrower.RandomGrenadeDelay;
    }

    public void Tick()
    {
      _toPlayerRotator.Rotate();
      _randomGrenadeDelayLeft -= Time.deltaTime;

      if (_randomGrenadeDelayLeft <= 0)
      {
        _grenadeThrower.Lauch();
        _stateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
      _randomGrenadeDelayLeft = _grenadeThrower.RandomGrenadeDelay;
    }
  }
}