using System;
using Loggers;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines.Infrastructure
{
  public abstract class PlayerTransition : ITickable
  {
    private Type _activeState;
    private int _processCount;

    public event Action<Type> Processed;

    public abstract void Tick();

    public void SetActiveState(Type type)
    {
      _activeState = type;
    }

    protected void Process(Type toState)
    {
      if (_activeState == toState)
        return;

      string message = GetType().Name;
      message = message.Replace("Player", "");
      message = message.Replace("Transition", "");
      message = message.Replace("State", "");
      new DebugLogger().Log($"<color=yellow>#{message}</color>");

      Processed?.Invoke(toState);
    }
  }
}