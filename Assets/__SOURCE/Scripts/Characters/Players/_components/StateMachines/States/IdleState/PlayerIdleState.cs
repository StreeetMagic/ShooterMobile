using System.Collections.Generic;
using Characters.FiniteStateMachines;

namespace Characters.Players._components.StateMachines.States.IdleState
{
  public class PlayerIdleState : State
  {
    private readonly PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;
    
    public PlayerIdleState(List<Transition> transitions, PlayerWeaponMagazineReloader playerWeaponMagazineReloader) : base(transitions)
    {
      _playerWeaponMagazineReloader = playerWeaponMagazineReloader;
    }

    public override void Enter()
    {
    }
    
    protected override void OnTick() 
    {
      if (_playerWeaponMagazineReloader.IsActive)
        _playerWeaponMagazineReloader.Tick();
    }

    public override void Exit()
    {
    }
  }
}