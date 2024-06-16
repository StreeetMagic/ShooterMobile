using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.AttackState;
using Gameplay.Characters.Players.StateMachines.States.BoostrapState;
using Gameplay.Characters.Players.StateMachines.States.DieState;
using Gameplay.Characters.Players.StateMachines.States.HideWeaponState;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Gameplay.Characters.Players.StateMachines.States.InterractState;
using Gameplay.Characters.Players.StateMachines.States.MoveState;
using Gameplay.Characters.Players.StateMachines.States.RiseWeaponState;
using Infrastructure.ZenjectFactories.GameobjectContext;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines
{
  public class PlayerFiniteStateMachine : ITickable
  {
    private readonly Dictionary<Type, PlayerState> _states;

    private PlayerState _activeState;

    public PlayerFiniteStateMachine(PlayerZenjectFactory factory)
    {
      _states = new Dictionary<Type, PlayerState>
      {
        {
          typeof(PlayerBootstrapState),
          factory.InstantiateNative<PlayerBootstrapState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerBootstrapToIdleTransition>()
            }
          )
        },

        {
          typeof(PlayerIdleState),
          factory.InstantiateNative<PlayerIdleState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerIdleToRiseWeaponTransition>(),
              factory.InstantiateNative<PlayerIdleToInterractTransition>()
            }
          )
        },

        {
          typeof(PlayerRiseWeaponState),
          factory.InstantiateNative<PlayerRiseWeaponState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerRiseWeaponToIdleTransition>(),
              factory.InstantiateNative<PlayerRiseWeaponToAttackTransition>(),
              factory.InstantiateNative<PlayerRiseWeaponToInterractTransition>()
            }
          )
        },

        {
          typeof(PlayerAttackState),
          factory.InstantiateNative<PlayerAttackState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerAttackToHideWeaponTransition>(),
            }
          )
        },

        {
          typeof(PlayerHideWeaponState),
          factory.InstantiateNative<PlayerHideWeaponState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerHideWeaponToIdleTransition>(),
              factory.InstantiateNative<PlayerHideWeaponToInterractTransition>(),
            }
          )
        },
        
        {
          typeof(PlayerInterractState),
          factory.InstantiateNative<PlayerInterractState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerInterractToIdleTransition>(),
              factory.InstantiateNative<PlayerInterractToRiseWeaponTransition>(),
            }
          )
        },  
        
        {
          typeof(PlayerMoveState),
          factory.InstantiateNative<PlayerMoveState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerMoveToIdleTransition>(),
              factory.InstantiateNative<PlayerMoveToRiseWeaponTransition>(),
              factory.InstantiateNative<PlayerMoveToInterractTransition>(),
            }
          )
        },       
        
        {
          typeof(PlayerDieState),
          factory.InstantiateNative<PlayerDieState>()
        },
      };

      _activeState = _states.Values.First();
      _activeState.Enter();

      foreach (PlayerState state in _states.Values)
        state.Processed += OnProcessed;
    }

    public void Tick()
    {
      _activeState.Tick();

      AnyState();
    }

    private void AnyState()
    {
    }

    private void OnProcessed(Type type)
    {
      _activeState.Exit();
      _activeState = _states[type];
      _activeState.Enter();
    }
  }
}