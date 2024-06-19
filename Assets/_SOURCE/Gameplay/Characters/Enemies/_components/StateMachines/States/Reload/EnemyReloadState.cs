using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Loggers;

namespace Gameplay.Characters.Enemies.StateMachines.States.Reload
{
  public class EnemyReloadState : State
  {
    private readonly EnemyWeaponMagazine _magazine;
    private readonly EnemyWeaponMagazineReloaderTimer _timer;

    public EnemyReloadState(List<Transition> transitions,
      EnemyWeaponMagazine magazine,
      EnemyWeaponMagazineReloaderTimer timer) : base(transitions)
    {
      _magazine = magazine;
      _timer = timer;
    }

    public override void Enter()
    {
      new DebugLogger().Log("Включаем анимацию перезарядки у противника");
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