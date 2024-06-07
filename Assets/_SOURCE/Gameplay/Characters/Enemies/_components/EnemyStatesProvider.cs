using System;
using System.Collections.Generic;
using StateMachine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyStatesProvider
  {
    private readonly Dictionary<Type, IState> _states = new();

    public void AddState(IState state)
    {
      _states.Add(state.GetType(), state);
    }

    public T GetState<T>() where T : IState
    {
      return (T)_states[typeof(T)];
    }
  }
}