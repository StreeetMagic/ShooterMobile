using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
{
  public class RiseWeaponToIdleTransition : Transition
  {
    private readonly PlayerTargetHolder _playerTargetHolder;

    public RiseWeaponToIdleTransition(IStateMachineFactory stateMachineFactory, PlayerTargetHolder playerTargetHolder) : base(stateMachineFactory)
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