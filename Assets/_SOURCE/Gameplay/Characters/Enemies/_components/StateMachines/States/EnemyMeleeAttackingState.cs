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
    private readonly EnemyAnimatorProvider _animatorProvider;

    private float _wholeTimeleft;

    private bool _attacked;

    public EnemyMeleeAttackingState(EnemyConfig config, EnemyMeleeAttacker meleeAttacker,
      EnemyStateMachine enemyStateMachine, EnemyAnimatorProvider animatorProvider)
    {
      _config = config;
      _meleeAttacker = meleeAttacker;
      _enemyStateMachine = enemyStateMachine;
      _animatorProvider = animatorProvider;
    }

    public void Enter()
    {
      _attacked = false;

      float wholeAttackTime = _config.MeeleAttackDuration;

      _wholeTimeleft = wholeAttackTime;

      _animatorProvider.Instance.PlayRandomKnifeHitAnimation(wholeAttackTime);

      _animatorProvider.Instance.KnifeHit += OnHitEventListener;
    }

    public void Tick()
    {
      _wholeTimeleft -= Time.deltaTime;

      if (_wholeTimeleft <= 0)
      {
        _enemyStateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
    }

    private void OnHitEventListener()
    {
      if (!_attacked)
      {
        _attacked = true;
        _meleeAttacker.Attack();
      }
    }
  }
}