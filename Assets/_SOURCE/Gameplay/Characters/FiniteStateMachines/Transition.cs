using System;
using Loggers;
using Zenject;

namespace Gameplay.Characters.FiniteStateMachines
{
  public abstract class Transition : ITickable
  {
    private State _activeState;
    private int _processCount;
    
    public event Action<Type> Entered;

    public abstract void Tick();

    public void SetActiveState(State state)
    {
      _activeState = state;
    }

    protected void Enter<T>() where T : class
    {
      if (_activeState.GetType() == typeof(T))
        return;

      string message = GetType().Name;
      message = message.Replace("Transition", "");
      message = message.Replace("State", "");
      new DebugLogger().LogTransition($"<color=yellow>#{message}</color>");

      Entered?.Invoke(typeof(T));
    }
  }
}