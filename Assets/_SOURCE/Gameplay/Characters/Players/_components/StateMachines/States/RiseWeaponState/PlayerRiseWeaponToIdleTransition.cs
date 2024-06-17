using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
{
  public class PlayerRiseWeaponToIdleTransition : Transition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerRiseWeaponToIdleTransition(IStateMachineFactory stateMachineFactory, PlayerTargetHolder playerTargetHolder) : base(stateMachineFactory)
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