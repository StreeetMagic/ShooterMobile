using Infrastructure.StateMachines.States;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Infrastructure.StateMachines
{
  public class StateMachine<TMainState>
    : IStateMachine<TMainState>, ITickable, IFixedTickable, ILateTickable
    where TMainState : class, IState
  {
    public IExitableState ActiveState { get; private set; }

    public void Enter<TState>() where TState : class, TMainState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, TMainState, IPayloadedState<TPayload> =>
      ChangeState<TState>().Enter(payload);

    public void Enter<TState, TPayload, TPayload2>(TPayload payload, TPayload2 payload2)
      where TState : class, TMainState, IPayloadedState<TPayload, TPayload2>
    {
      var state = ChangeState<TState>();
      state.Enter(payload, payload2);
    }

    public TState Register<TState>(TState implementation) where TState : TMainState =>
      Implementation<TState>.Instance = implementation;

    public TState Get<TState>() where TState : class, TMainState =>
      Implementation<TState>.Instance;

    private TState ChangeState<TState>() where TState : class, TMainState, IExitableState
    {
      ActiveState?.Exit();
      var state = Get<TState>();
      ActiveState = state;
      return state;
    }

    public void Tick()
    {
      if (ActiveState is ITickable tickable)
        tickable.Tick();
    }

    public void FixedTick()
    {
      if (ActiveState is IFixedTickable fixedTickable)
        fixedTickable.FixedTick();
    }

    public void LateTick()
    {
      if (ActiveState is ILateTickable lateTickable)
        lateTickable.LateTick();
    }
  }
}