using System;
using System.Collections.Generic;

namespace Gameplay.Characters.FiniteStateMachines
{
  public interface IStateMachineFactory
  {
    string GetName();
    Dictionary<Type, State> GetStates();
    Dictionary<Type, Transition> GetAnyStateTransitions();
  }
}