using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.StateMachines;
using Gameplay.Characters.Enemies.StateMachines._old.States.Switchers;
using Gameplay.Characters.FiniteStateMachines;
using Infrastructure.ZenjectFactories.GameobjectContext;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyStateMachineFactory : IStateMachineFactory
  {
    private readonly EnemyZenjectFactory _factory;

    public string GetName() =>
      "Enemy";

    public Dictionary<Type, State> GetStates()
    {
      return new Dictionary<Type, State>()
      {
        {
          typeof(EnemyBootstrapState),
          _factory.InstantiateNative<EnemyBootstrapState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyBootstrapToIdleTransition>()
            }
          )
        },

        {
          typeof(EnemyIdleState),
          _factory.InstantiateNative<EnemyIdleState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyIdleToPatrolTransition>(),
              _factory.InstantiateNative<EnemyIdleToAlertTransition>()
            }
          )
        },

        {
          typeof(EnemyAlertState),
          _factory.InstantiateNative<EnemyAlertState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyAlertToChaseTransition>()
            }
          )
        },

        {
          typeof(EnemyChaseState),
          _factory.InstantiateNative<EnemyChaseState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyChaseToMeleeAttackTransition>(),
              _factory.InstantiateNative<EnemyChaseToThrowGrenadeTransition>(),
              _factory.InstantiateNative<EnemyChaseToRaiseWeaponTransition>(),
              _factory.InstantiateNative<EnemyChaseToReturnTransition>(),
            }
          )
        },

        {
          typeof(EnemyPatrolState),
          _factory.InstantiateNative<EnemyPatrolState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyPatrolToIdleTransition>(),
              _factory.InstantiateNative<EnemyPatrolToAlertTransition>(),
            }
          )
        },

        {
          typeof(EnemyMeleeAttackState),
          _factory.InstantiateNative<EnemyMeleeAttackState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyMeleeAttackToChaseTransition>(),
            }
          )
        },

        {
          typeof(EnemyThrowGrenadeState),
          _factory.InstantiateNative<EnemyThrowGrenadeState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyThrowGrenadeToChaseTransition>(),
            }
          )
        },

        {
          typeof(EnemyReloadState),
          _factory.InstantiateNative<EnemyReloadState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyReloadToChaseTransition>(),
            }
          )
        },

        {
          typeof(EnemyRaiseWeaponState),
          _factory.InstantiateNative<EnemyRaiseWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyRaiseWeaponToShootTransition>(),
            }
          )
        },

        {
          typeof(EnemyShootState),
          _factory.InstantiateNative<EnemyShootState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyShootToLowWeaponTransition>(),
            }
          )
        },

        {
          typeof(EnemyLowWeaponState),
          _factory.InstantiateNative<EnemyLowWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyLowWeaponToReloadTransition>(),
              _factory.InstantiateNative<EnemyLowWeaponToChaseTransition>(),
              _factory.InstantiateNative<EnemyLowWeaponToReturnTransition>(),
            }
          )
        },

        {
          typeof(EnemyReturnState),
          _factory.InstantiateNative<EnemyReturnState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<EnemyReturnToIdleTransition>(),
            }
          )
        },

        {
          typeof(EnemyDieState),
          _factory.InstantiateNative<EnemyDieState>
          (
            new List<Transition>
            {
            }
          )
        },
      };
    }
  }

  public class EnemyThrowGrenadeToChaseTransition : Transition
  {
    public EnemyThrowGrenadeToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyThrowGrenadeState : State
  {
    public EnemyThrowGrenadeState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyMeleeAttackToChaseTransition : Transition
  {
    public EnemyMeleeAttackToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyMeleeAttackState : State
  {
    public EnemyMeleeAttackState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyPatrolToAlertTransition : Transition
  {
    public EnemyPatrolToAlertTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyPatrolToIdleTransition : Transition
  {
    public EnemyPatrolToIdleTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyPatrolState : State
  {
    public EnemyPatrolState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyChaseToMeleeAttackTransition : Transition
  {
    public EnemyChaseToMeleeAttackTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyChaseToThrowGrenadeTransition : Transition
  {
    public EnemyChaseToThrowGrenadeTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyChaseToRaiseWeaponTransition : Transition
  {
    public EnemyChaseToRaiseWeaponTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyChaseToReturnTransition : Transition
  {
    public EnemyChaseToReturnTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyChaseState : State
  {
    public EnemyChaseState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyAlertToChaseTransition : Transition
  {
    public EnemyAlertToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyAlertState : State
  {
    public EnemyAlertState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyIdleToAlertTransition : Transition
  {
    public EnemyIdleToAlertTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyIdleToPatrolTransition : Transition
  {
    public EnemyIdleToPatrolTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }

  public class EnemyIdleState : State
  {
    public EnemyIdleState(List<Transition> transitions) : base(transitions)
    {
    }

    public override void Enter()
    {
      throw new NotImplementedException();
    }

    public override void Exit()
    {
      throw new NotImplementedException();
    }
  }
  
  public class EnemyReloadToChaseTransition : Transition
  {
    public EnemyReloadToChaseTransition(IStateMachineFactory stateMachineFactory) : base(stateMachineFactory)
    {
    }

    public override void Tick()
    {
      throw new NotImplementedException();
    }
  }
}