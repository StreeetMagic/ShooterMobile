using System;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines.Infrastructure
{
  public abstract class PlayerTransition : ITickable
  {
    public event Action<Type> Processed;

    public abstract void Tick();

    protected void Process(Type type)
    {
      Processed?.Invoke(type);
    }
  }
}