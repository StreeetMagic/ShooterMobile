using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.Boostrap;
using Gameplay.Characters.Players.StateMachines.States.Boostrap.Transitions;
using Gameplay.Characters.Players.StateMachines.States.Idle;
using Infrastructure.ZenjectFactories.GameobjectContext;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines
{
  public class PlayerFiniteStateMachine : ITickable
  {
    private readonly Dictionary<Type, PlayerState> _states;

    private PlayerState _activeState;

    public PlayerFiniteStateMachine(PlayerZenjectFactory factory)
    {
      _activeState = factory.InstantiateNative<PlayerBootstrapState>(
        new List<PlayerTransition>
        {
          factory.InstantiateNative<PlayerBootstrapToIdleTransition>()
        });
      
      _activeState.Enter();

      _states = new Dictionary<Type, PlayerState>
      {
        { typeof(PlayerBootstrapState), _activeState },

        { typeof(PlayerIdleState), factory.InstantiateNative<PlayerIdleState>() },
      };

      _states[typeof(PlayerBootstrapState)].Processed += OnProcessed;
      _states[typeof(PlayerIdleState)].Processed += OnProcessed;
    }

    public void Tick()
    {
      _activeState.Tick();

      AnyState();
    }

    private void AnyState()
    {
    }

    private void OnProcessed(Type type)
    {
      _activeState.Exit();
      _activeState = _states[type];
      _activeState.Enter();
    }
  }
}