using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;

namespace Gameplay.Characters.Players.StateMachines.States.LowWeaponState
{
  public class LowWeaponToIdleTransition : Transition
  {
    private readonly PlayerWeaponLowerer _playerWeaponLowerer;

    public LowWeaponToIdleTransition(IStateMachineFactory stateMachineFactory, PlayerWeaponLowerer playerWeaponLowerer) : base(stateMachineFactory)
    {
      _playerWeaponLowerer = playerWeaponLowerer;
    }

    public override void Tick()
    {
      if (!_playerWeaponLowerer.IsLowered)
        Process<PlayerIdleState>();

      _playerWeaponLowerer.Tick();
    }
  }
}