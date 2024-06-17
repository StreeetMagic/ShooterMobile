using System;
using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.AttackState;
using Gameplay.Characters.Players.StateMachines.States.BoostrapState;
using Gameplay.Characters.Players.StateMachines.States.DieState;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Gameplay.Characters.Players.StateMachines.States.InterractState;
using Gameplay.Characters.Players.StateMachines.States.LowWeaponState;
using Gameplay.Characters.Players.StateMachines.States.MoveState;
using Gameplay.Characters.Players.StateMachines.States.RiseWeaponState;
using Infrastructure.ZenjectFactories.GameobjectContext;

namespace Gameplay.Characters.Players.StateMachines
{
  public class PlayerStateMachineFactory : IStateMachineFactory
  {
    private readonly PlayerZenjectFactory _factory;

    public PlayerStateMachineFactory(PlayerZenjectFactory factory)
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
              _factory.InstantiateNative<BootstrapToIdleTransition>()
            }
          )
        },

        {
          typeof(PlayerIdleState),
          _factory.InstantiateNative<PlayerIdleState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<IdleToRiseWeaponTransition>(),
              _factory.InstantiateNative<IdleToInterractTransition>()
            }
          )
        },

        {
          typeof(PlayerRiseWeaponState),
          _factory.InstantiateNative<PlayerRiseWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<RiseWeaponToIdleTransition>(),
              _factory.InstantiateNative<RiseWeaponToAttackTransition>(),
            }
          )
        },

        {
          typeof(PlayerAttackState),
          _factory.InstantiateNative<PlayerAttackState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<AttackToLowWeaponTransition>(),
            }
          )
        },

        {
          typeof(PlayerLowWeaponState),
          _factory.InstantiateNative<PlayerLowWeaponState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<LowWeaponToIdleTransition>(),
            }
          )
        },

        {
          typeof(PlayerInterractState),
          _factory.InstantiateNative<PlayerInterractState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<InterractToIdleTransition>(),
              _factory.InstantiateNative<InterractToRiseWeaponTransition>(),
            }
          )
        },

        {
          typeof(PlayerMoveState),
          _factory.InstantiateNative<PlayerMoveState>
          (
            new List<Transition>
            {
              _factory.InstantiateNative<MoveToIdleTransition>(),
            }
          )
        },

        {
          typeof(PlayerDieState),
          _factory.InstantiateNative<PlayerDieState>()
        },
      };
    }
  }
}