using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
{
  public class PlayerRiseWeaponToIdleTransition : PlayerTransition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerRiseWeaponToIdleTransition(PlayerTargetHolder playerTargetHolder)
    {
      _playerTargetHolder = playerTargetHolder;
    }

    public override void Tick()
    {
      if (_playerTargetHolder.HasTarget == false)
        Process<PlayerIdleState>();
    }
  }
}