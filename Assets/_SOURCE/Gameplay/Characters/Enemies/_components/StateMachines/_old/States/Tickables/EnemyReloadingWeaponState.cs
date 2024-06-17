using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.StateMachines._old.States.Tickables
{
  public class EnemyReloadingWeaponState :  ITickable
  {
    private readonly EnemyWeaponReloader _reloader;
    private readonly EnemyConfig _config;


    private float _timeLeft;

    public EnemyReloadingWeaponState(EnemyWeaponReloader reloader, EnemyConfig config)
    {
      _reloader = reloader;

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

       // _oldEnemyStateMachine.Enter<EnemyChooseAttackState>();
      }
    }

    public void Exit()
    {
    }
  }
}