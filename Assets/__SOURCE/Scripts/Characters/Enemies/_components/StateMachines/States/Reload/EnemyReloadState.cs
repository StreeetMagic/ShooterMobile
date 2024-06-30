using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Reload
{
  public class EnemyReloadState : State
  {
    private readonly EnemyWeaponMagazine _magazine;
    private readonly EnemyWeaponMagazineReloaderTimer _timer;
    private readonly EnemyAnimatorProvider _animator;

    public EnemyReloadState(List<Transition> transitions,
      EnemyWeaponMagazine magazine,
      EnemyWeaponMagazineReloaderTimer timer, EnemyAnimatorProvider animator) : base(transitions)
    {
      _magazine = magazine;
      _timer = timer;
      _animator = animator;
    }

    public override void Enter()
    {
      _animator.Instance.PlayReload();
      _timer.Reset();
    }

    protected override void OnTick()
    {
      if (_timer.IsDone)
      {
        _magazine.Reload();
        return;
      }

      _timer.Tick();
    }

    public override void Exit()
    {
    }
  }
}