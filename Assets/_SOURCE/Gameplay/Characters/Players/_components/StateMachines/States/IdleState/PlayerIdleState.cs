using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
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
    
    public override void Tick()
    {
      base.Tick();
      
      if (_playerWeaponMagazineReloader.IsActive)
        _playerWeaponMagazineReloader.Tick();
    }

    public override void Exit()
    {
    }
  }
}