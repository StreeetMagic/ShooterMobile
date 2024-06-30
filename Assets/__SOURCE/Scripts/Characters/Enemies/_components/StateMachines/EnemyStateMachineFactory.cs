using System;
using System.Collections.Generic;
using Characters.Enemies._components.StateMachines.AnyStatesTransitions;
using Characters.Enemies._components.StateMachines.States.Alert;
using Characters.Enemies._components.StateMachines.States.Bootstrap;
using Characters.Enemies._components.StateMachines.States.Chase;
using Characters.Enemies._components.StateMachines.States.Die;
using Characters.Enemies._components.StateMachines.States.Idle;
using Characters.Enemies._components.StateMachines.States.LowWeapon;
using Characters.Enemies._components.StateMachines.States.MeleeAttack;
using Characters.Enemies._components.StateMachines.States.Patrol;
using Characters.Enemies._components.StateMachines.States.RaiseWeapon;
using Characters.Enemies._components.StateMachines.States.Reload;
using Characters.Enemies._components.StateMachines.States.Return;
using Characters.Enemies._components.StateMachines.States.Shoot;
using Characters.Enemies._components.StateMachines.States.ThrowGrenade;
using Characters.FiniteStateMachines;
using Infrastructure.ZenjectFactories.GameobjectContext;

namespace Characters.Enemies._components.StateMachines
{
  public class EnemyStateMachineFactory : IStateMachineFactory
  {
    private readonly IGameObjectZenjectFactory _factory;

    public EnemyStateMachineFactory(IGameObjectZenjectFactory factory)
    {
      _factory = factory;
    }

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
              _factory.InstantiateNative<EnemyChaseToReloadTransition>(),
              _factory.InstantiateNative<EnemyChaseToReturnTransition>(),
              _factory.InstantiateNative<EnemyChaseToMeleeAttackTransition>(),
              _factory.InstantiateNative<EnemyChaseToThrowGrenadeTransition>(),
              _factory.InstantiateNative<EnemyChaseToRaiseWeaponTransition>(),
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
              _factory.InstantiateNative<EnemyLowWeaponToChaseTransition>(),
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
            new List<Transition>() 
          )
        },
      };
    }

    public Dictionary<Type, Transition> GetAnyStateTransitions()
    {
      return new Dictionary<Type, Transition>
      {
        {
          typeof(EnemyAnyStateToDie),
          _factory.InstantiateNative<EnemyAnyStateToDie>()
        },
      };
    }
  }
}