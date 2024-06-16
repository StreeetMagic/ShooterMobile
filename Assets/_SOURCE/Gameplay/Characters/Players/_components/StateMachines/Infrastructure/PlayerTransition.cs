using System;
using Loggers;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines.Infrastructure
{
  public abstract class PlayerTransition : ITickable
  {
    protected PlayerState ActiveState;
    private int _processCount;

    public event Action<Type> Processed;

    public abstract void Tick();

    public void SetActiveState(PlayerState state)
    {
      ActiveState = state;
    }

    protected void Process<T>() where T : class
    {
      if (ActiveState.GetType() == typeof(T))
        return;

      string message = GetType().Name;
      message = message.Replace("Player", "");
      message = message.Replace("Transition", "");
      message = message.Replace("State", "");
      new DebugLogger().Log($"<color=yellow>#{message}</color>");

      Processed?.Invoke(typeof(T));
    }
  }
}