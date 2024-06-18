using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.Characters.FiniteStateMachines
{
  public abstract class State : ITickable
  {
    private State _activeState;

    private readonly List<Transition> _transitions;

    protected State(List<Transition> transitions)
    {
      _transitions = transitions;

      foreach (Transition transition in _transitions)
      {
        transition.Entered += Process;
      }
    }

    public event Action<Type> Processed;

    public void Tick()
    {
      OnTick();
      
      foreach (Transition transition in _transitions)
      {
        transition.SetActiveState(_activeState);
        transition.Tick();
      }
    }

    public abstract void Enter();
    public abstract void Exit();

    public void SetActiveState(State state)
    {
      _activeState = state;
    }

    private void Process(Type type)
    {
      Processed?.Invoke(type);
    }

    protected virtual void OnTick() { }
  }
}