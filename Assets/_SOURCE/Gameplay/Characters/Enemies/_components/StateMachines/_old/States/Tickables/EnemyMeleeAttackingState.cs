using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables
{
  public class EnemyMeleeAttackingState : ITickable
  {
    private readonly EnemyConfig _config;
    private readonly EnemyMeleeAttacker _meleeAttacker;

    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyToPlayerRotator _toPlayerRotator;

    private float _wholeTimeleft;
    private bool _attacked;

    public EnemyMeleeAttackingState(EnemyConfig config, EnemyMeleeAttacker meleeAttacker,
      EnemyToPlayerRotator toPlayerRotator, EnemyAnimatorProvider animatorProvider)
    {
      _config = config;
      _meleeAttacker = meleeAttacker;

      _animatorProvider = animatorProvider;
      _toPlayerRotator = toPlayerRotator;
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
      _toPlayerRotator.Rotate();
      _wholeTimeleft -= Time.deltaTime;

      // if (_wholeTimeleft / _config.MeeleAttackDuration < 0.5f && !_attacked)
      // {
      //   _attacked = true;
      //   _meleeAttacker.Attack();
      // }

      // if (_wholeTimeleft <= 0)
      //   _oldEnemyStateMachine.Enter<EnemyChooseAttackState>();
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