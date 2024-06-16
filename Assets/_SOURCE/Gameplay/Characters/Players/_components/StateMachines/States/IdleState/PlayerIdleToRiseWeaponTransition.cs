using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.RiseWeaponState;

namespace Gameplay.Characters.Players.StateMachines.States.IdleState
{
  public class PlayerIdleToRiseWeaponTransition : PlayerTransition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerIdleToRiseWeaponTransition(PlayerTargetHolder playerTargetHolder)
    {
      _playerTargetHolder = playerTargetHolder;
    }

    public override void Tick()
    {
      if (_playerTargetHolder.HasTarget)
        Process<PlayerRiseWeaponState>( );
    }
  }
}