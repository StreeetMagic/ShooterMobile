using Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines.States
{
  public class EnemyReloadingWeaponState : IState, ITickable
  {
    private readonly EnemyWeaponReloader _reloader;
    private readonly EnemyConfig _config;
    private readonly EnemyStateMachine _enemyStateMachine;

    private float _timeLeft;

    public EnemyReloadingWeaponState(EnemyWeaponReloader reloader, EnemyStateMachine enemyStateMachine, EnemyConfig config)
    {
      _reloader = reloader;
      _enemyStateMachine = enemyStateMachine;
      _config = config;
    }

    public void Enter()
    {
      _timeLeft = _config.MagazineReloadTime;
    }

    public void Tick()
    {
      _timeLeft -= Time.deltaTime;

      if (_timeLeft <= 0)
      {
        _reloader.Reload();

        _enemyStateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
    }
  }
}