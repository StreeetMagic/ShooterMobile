using StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyMeleeAttackingState : IState, ITickable
  {
    private readonly EnemyConfig _config;
    private readonly EnemyMeleeAttacker _meleeAttacker;
    private readonly EnemyStateMachine _enemyStateMachine;

    private float _wholeTimeleft;
    private float _attackTimeleft;
    private bool _attacked;

    public EnemyMeleeAttackingState(EnemyConfig config, EnemyMeleeAttacker meleeAttacker, EnemyStateMachine enemyStateMachine)
    {
      _config = config;
      _meleeAttacker = meleeAttacker;
      _enemyStateMachine = enemyStateMachine;
    }

    public void Enter()
    {
      _attacked = false;

      float wholeAttackTime = _config.MeeleAttackDuration;
      float halfTime = wholeAttackTime / 2;

      _wholeTimeleft = wholeAttackTime;
      _attackTimeleft = halfTime;
    }

    public void Tick()
    {
      _wholeTimeleft -= Time.deltaTime;
      _attackTimeleft -= Time.deltaTime;

      if (_attackTimeleft <= 0 && !_attacked)
      {
        _attacked = true;
        _meleeAttacker.Attack();
      }

      if (_wholeTimeleft <= 0)
      {
        _enemyStateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
    }
  }
}