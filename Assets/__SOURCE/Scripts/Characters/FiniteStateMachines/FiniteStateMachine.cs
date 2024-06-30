using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Loggers;
using Zenject;

namespace Characters.FiniteStateMachines
{
  public class FiniteStateMachine : ITickable
  {
    private readonly Dictionary<Type, Transition> _anyStateTransitions;
    private readonly Dictionary<Type, State> _states;

    private State _activeState;

    public FiniteStateMachine(IStateMachineFactory stateMachineFactory)
    {
      _states = stateMachineFactory.GetStates();
      _anyStateTransitions = stateMachineFactory.GetAnyStateTransitions();

      _activeState = _states.Values.First();
      EnterActiveState();

      foreach (State state in _states.Values)
        state.Entered += OnEntered;

      foreach (Transition transition in _anyStateTransitions.Values)
        transition.Entered += OnEntered;
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

    private void OnEntered(Type toState)
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
      name = name.Replace("State", "");
      new DebugLogger().LogStateEnter($"<color=green>>{name}</color>");
    }

    private void ExitActiveState()
    {
      _activeState.Exit();

      string name = _activeState.GetType().Name;
      name = name.Replace("State", "");
      new DebugLogger().LogStateExit($"<color=red><{name}</color>");
    }
  }
}