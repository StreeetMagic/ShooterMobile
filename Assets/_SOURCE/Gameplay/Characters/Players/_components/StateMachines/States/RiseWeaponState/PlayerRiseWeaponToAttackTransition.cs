using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.AttackState;

namespace Gameplay.Characters.Players.StateMachines.States.RiseWeaponState
{
  public class RiseWeaponToAttackTransition : Transition
  {
    private readonly PlayerWeaponRaiser _playerWeaponRaiser;

    public RiseWeaponToAttackTransition(IStateMachineFactory stateMachineFactory, PlayerWeaponRaiser playerWeaponRaiser) : base(stateMachineFactory)
    {
      _playerWeaponRaiser = playerWeaponRaiser;
    }

    public override void Tick()
    {
      if (_playerWeaponRaiser.IsRaised)
        Process<PlayerAttackState>();
      
      _playerWeaponRaiser.Tick();
    }
  }
}