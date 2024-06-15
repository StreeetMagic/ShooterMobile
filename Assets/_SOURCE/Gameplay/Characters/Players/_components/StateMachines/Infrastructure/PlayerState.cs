using System;
using System.Collections.Generic;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines.Infrastructure
{
  public abstract class PlayerState : ITickable
  {
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
        transition.Tick();
    }

    public abstract void Enter();
    public abstract void Exit();

    private void Process(Type type)
    {
      Processed?.Invoke(type);
    }
  }
}