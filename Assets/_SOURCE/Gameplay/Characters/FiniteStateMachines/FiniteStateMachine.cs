using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.AnyStateTransitions;
using Gameplay.Characters.Players.StateMachines.States.BoostrapState;
using Infrastructure.ZenjectFactories.GameobjectContext;
using Loggers;
using Zenject;

namespace Gameplay.Characters.FiniteStateMachines
{
  public class FiniteStateMachine : ITickable
  {
    private readonly Dictionary<Type, Transition> _anyStateTransitions;
    private readonly string _ownerName;
    private readonly Dictionary<Type, State> _states;

    private State _activeState;

    public FiniteStateMachine(PlayerZenjectFactory zenjectFactory, IStateMachineFactory stateMachineFactory)
    {
      _ownerName = stateMachineFactory.GetName();
      _states = stateMachineFactory.GetStates();

      _activeState = _states[typeof(PlayerBootstrapState)];
      EnterActiveState();

      foreach (State state in _states.Values)
        state.Processed += OnProcessed;

      _anyStateTransitions = new Dictionary<Type, Transition>
      {
        {
          typeof(AnyStateToMoveTransition),
          zenjectFactory.InstantiateNative<AnyStateToMoveTransition>()
        },
        {
          typeof(AnyStateToDieTransition),
          zenjectFactory.InstantiateNative<AnyStateToDieTransition>()
        },
      };

      foreach (Transition transition in _anyStateTransitions.Values)
        transition.Processed += OnProcessed;
    }

    public void Tick()
    {
      foreach (Transition transition in _anyStateTransitions.Values)
      {
        transition.SetActiveState(_activeState);
        transition.Tick();
      }

      _activeState.SetActiveState(_activeState);
      _activeState.Tick();
    }

    private void OnProcessed(Type toState)
    {
      if (_states.TryGetValue(toState, out State state) == false)
        throw new Exception($"State {toState} not found");

      if (state == _activeState)
        return;

      ExitActiveState();
      _activeState = _states[toState];
      EnterActiveState();
    }

    private void EnterActiveState()
    {
      _activeState.Enter();

      string name = _activeState.GetType().Name;
      name = name.Replace(_ownerName, "");
      name = name.Replace("State", "");
      new DebugLogger().Log($"<color=green>>{name}</color>");
    }

    private void ExitActiveState()
    {
      _activeState.Exit();

      string name = _activeState.GetType().Name;
      name = name.Replace(_ownerName, "");
      name = name.Replace("State", "");
      new DebugLogger().Log($"<color=red><{name}</color>");
    }
  }
}