using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleState : PlayerState
  {
    private PlayerWeaponMagazineReloader _playerWeaponMagazineReloader;
    
    public PlayerIdleState(List<PlayerTransition> transitions, PlayerWeaponMagazineReloader playerWeaponMagazineReloader) : base(transitions)
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