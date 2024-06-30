using System;
using System.Collections.Generic;
using Characters.FiniteStateMachines;
using Characters.Players._components.StateMachines.AnyStateTransitions;
using Characters.Players._components.StateMachines.States.AttackState;
using Characters.Players._components.StateMachines.States.BoostrapState;
using Characters.Players._components.StateMachines.States.DieState;
using Characters.Players._components.StateMachines.States.IdleState;
using Characters.Players._components.StateMachines.States.InterractState;
using Characters.Players._components.StateMachines.States.LowWeaponState;
using Characters.Players._components.StateMachines.States.MoveState;
using Characters.Players._components.StateMachines.States.RiseWeaponState;
using Infrastructure.ZenjectFactories.GameobjectContext;

namespace Characters.Players._components.StateMachines
{
  public class PlayerStateMachineFactory : IStateMachineFactory
  {
    private readonly IGameObjectZenjectFactory _factory;

    public PlayerStateMachineFactory(IGameObjectZenjectFactory factory)
    {
      _factory = factory;
    }

    public string GetName()
    {
      return "Player";
    }

    public Dictionary<Type, State> GetStates()
    {
      return new Dictionary<Type, State>
      {
        {
          typeof(PlayerBootstrapState),
          _factory.InstantiateNative<PlayerBootstrapState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerBootstrapToIdleTransition>()
            }
          )
        },

        {
          typeof(PlayerIdleState),
          _factory.InstantiateNative<PlayerIdleState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerIdleToRiseWeaponTransition>(),
              _factory.InstantiateNative<PlayerIdleToInterractTransition>()
            }
          )
        },

        {
          typeof(PlayerRiseWeaponState),
          _factory.InstantiateNative<PlayerRiseWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerRiseWeaponToIdleTransition>(),
              _factory.InstantiateNative<PlayerRiseWeaponToAttackTransition>(),
            }
          )
        },

        {
          typeof(PlayerAttackState),
          _factory.InstantiateNative<PlayerAttackState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerAttackToLowWeaponTransition>(),
            }
          )
        },

        {
          typeof(PlayerLowWeaponState),
          _factory.InstantiateNative<PlayerLowWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerLowWeaponToIdleTransition>(),
            }
          )
        },

        {
          typeof(PlayerInterractState),
          _factory.InstantiateNative<PlayerInterractState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerInterractToIdleTransition>(),
              _factory.InstantiateNative<PlayerInterractToRiseWeaponTransition>(),
            }
          )
        },

        {
          typeof(PlayerMoveState),
          _factory.InstantiateNative<PlayerMoveState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<PlayerMoveToIdleTransition>(),
            }
          )
        },

        {
          typeof(PlayerDieState),
          _factory.InstantiateNative<PlayerDieState>()
        },
      };
    }

    public Dictionary<Type, Transition> GetAnyStateTransitions()
    {
      return new Dictionary<Type, Transition>
      {
        {
          typeof(PlayerAnyStateToMoveTransition),
          _factory.InstantiateNative<PlayerAnyStateToMoveTransition>()
        },
        {
          typeof(PlayerAnyStateToDieTransition),
          _factory.InstantiateNative<PlayerAnyStateToDieTransition>()
        },
      };
    }
  }
}