using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines.Infrastructure
{
  public abstract class PlayerState : ITickable
  {
    private Type _activeStateType;
    private PlayerState _activeState;
      
    private readonly List<PlayerTransition> _transitions;

    protected PlayerState(List<PlayerTransition> transitions)
    {
      _transitions = transitions;

      foreach (PlayerTransition transition in _transitions)
      {
        transition.Processed += Process;
      }
    }

    public event Action<Type> Processed;

    public virtual void Tick()
    {
      foreach (PlayerTransition transition in _transitions)
      {
        transition.SetActiveState(_activeState);
        transition.Tick();
      }
    }

    public abstract void Enter();
    public abstract void Exit();

    public void SetActiveState(PlayerState state)
    {
      _activeState = state;
      _activeStateType = _activeState.GetType();
    }

    private void Process(Type type)
    {
      Processed?.Invoke(type);
    }
  }
}