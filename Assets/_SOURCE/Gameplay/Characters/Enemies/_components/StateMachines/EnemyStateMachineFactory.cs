using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.StateMachines.States.Alert;
using Gameplay.Characters.Enemies.StateMachines.States.Bootstrap;
using Gameplay.Characters.Enemies.StateMachines.States.Chase;
using Gameplay.Characters.Enemies.StateMachines.States.Die;
using Gameplay.Characters.Enemies.StateMachines.States.Idle;
using Gameplay.Characters.Enemies.StateMachines.States.LowWeapon;
using Gameplay.Characters.Enemies.StateMachines.States.MeleeAttack;
using Gameplay.Characters.Enemies.StateMachines.States.Patrol;
using Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon;
using Gameplay.Characters.Enemies.StateMachines.States.Reload;
using Gameplay.Characters.Enemies.StateMachines.States.Return;
using Gameplay.Characters.Enemies.StateMachines.States.Shoot;
using Gameplay.Characters.Enemies.StateMachines.States.ThrowGrenade;
using Gameplay.Characters.FiniteStateMachines;
using Infrastructure.ZenjectFactories;
using Infrastructure.ZenjectFactories.GameobjectContext;

namespace Gameplay.Characters.Enemies.StateMachines
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
}