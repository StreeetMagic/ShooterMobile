using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables
{
  public class EnemyThrowingGrenadeState : ITickable
  {
    private readonly EnemyGrenadeThrower _grenadeThrower;
    private readonly EnemyToPlayerRotator _toPlayerRotator;

    private float _randomGrenadeDelayLeft;

    public EnemyThrowingGrenadeState(EnemyGrenadeThrower grenadeThrower,
      EnemyToPlayerRotator toPlayerRotator)
    {
      _grenadeThrower = grenadeThrower;

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

      if (_grenadeThrower.ReadyToThrow == false)
        //_stateMachine.Enter<EnemyChooseAttackState>();

        if (_randomGrenadeDelayLeft <= 0)
        {
          _grenadeThrower.Lauch();
          // _stateMachine.Enter<EnemyChooseAttackState>();
        }
    }

    public void Exit()
    {
      _randomGrenadeDelayLeft = _grenadeThrower.RandomGrenadeDelay;
    }
  }
}