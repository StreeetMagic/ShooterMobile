using System;
using Loggers;
using Zenject;

namespace Gameplay.Characters.FiniteStateMachines
{
  public abstract class Transition : ITickable
  {
    private readonly string _ownerName;

    private State _activeState;
    private int _processCount;

    protected Transition(IStateMachineFactory stateMachineFactory)
    {
      _ownerName = stateMachineFactory.GetName();
    }

    public event Action<Type> Processed;

    public abstract void Tick();

    public void SetActiveState(State state)
    {
      _activeState = state;
    }

    protected void Process<T>() where T : class
    {
      if (_activeState.GetType() == typeof(T))
        return;

      string message = GetType().Name;
      message = message.Replace(_ownerName, "");
      message = message.Replace("Transition", "");
      message = message.Replace("State", "");
      new DebugLogger().Log($"<color=yellow>#{message}</color>");

      Processed?.Invoke(typeof(T));
    }
  }
}