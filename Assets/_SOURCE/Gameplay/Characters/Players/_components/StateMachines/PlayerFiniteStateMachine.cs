using System;
using System.Collections.Generic;
using Gameplay.Characters.Players.StateMachines.AnyStateTransitions;
using Gameplay.Characters.Players.StateMachines.Infrastructure;
using Gameplay.Characters.Players.StateMachines.States.AttackState;
using Gameplay.Characters.Players.StateMachines.States.BoostrapState;
using Gameplay.Characters.Players.StateMachines.States.DieState;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using Gameplay.Characters.Players.StateMachines.States.InterractState;
using Gameplay.Characters.Players.StateMachines.States.LowWeaponState;
using Gameplay.Characters.Players.StateMachines.States.MoveState;
using Gameplay.Characters.Players.StateMachines.States.RiseWeaponState;
using Infrastructure.ZenjectFactories.GameobjectContext;
using Loggers;
using Zenject;

namespace Gameplay.Characters.Players.StateMachines
{
  public class PlayerFiniteStateMachine : ITickable
  {
    private readonly Dictionary<Type, PlayerState> _states;
    private readonly Dictionary<Type, PlayerTransition> _anyStateTransitions;

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
          typeof(PlayerLowWeaponState),
          factory.InstantiateNative<PlayerLowWeaponState>
          (
            new List<PlayerTransition>
            {
              factory.InstantiateNative<PlayerLowWeaponToIdleTransition>(),
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
            }
          )
        },

        {
          typeof(PlayerDieState),
          factory.InstantiateNative<PlayerDieState>()
        },
      };

      _activeState = _states[typeof(PlayerBootstrapState)];
      EnterActiveState();

      foreach (PlayerState state in _states.Values)
        state.Processed += OnProcessed;

      _anyStateTransitions = new Dictionary<Type, PlayerTransition>
      {
        {
          typeof(PlayerAnyStateToMoveTransition),
          factory.InstantiateNative<PlayerAnyStateToMoveTransition>()
        },
        {
          typeof(PlayerAnyStateToDieTransition),
          factory.InstantiateNative<PlayerAnyStateToDieTransition>()
        },
      };

      foreach (PlayerTransition transition in _anyStateTransitions.Values)
        transition.Processed += OnProcessed; 
    }

    public void Tick()
    {
      foreach (PlayerTransition transition in _anyStateTransitions.Values)
      {
        transition.SetActiveState(_activeState);
        transition.Tick();
      }

      _activeState.SetActiveState(_activeState);
      _activeState.Tick();
    }

    private void OnProcessed(Type toState)
    {
      if (_states.TryGetValue(toState, out PlayerState state) == false)
        throw new Exception($"State {toState} not found");

      if (state == _activeState)
        return;

      ExitActiveState();
      _activeState = _states[toState];
      EnterActiveState();
    }

    private void EnterActiveState()
    {
      _activeState.Enter();

      string name = _activeState.GetType().Name;
      name = name.Replace("Player", "");
      name = name.Replace("State", "");
      new DebugLogger().Log($"<color=green>>{name}</color>");
    }

    private void ExitActiveState()
    {
      _activeState.Exit();

      string name = _activeState.GetType().Name;
      name = name.Replace("Player", "");
      name = name.Replace("State", "");
      new DebugLogger().Log($"<color=red><{name}</color>");
    }
  }
}