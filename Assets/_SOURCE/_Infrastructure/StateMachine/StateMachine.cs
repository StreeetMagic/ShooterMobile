namespace PUNBALL.Infrastructure.StateMachine
{
  public abstract class StateMachine
  {
    public IExitableState ActiveState { get; protected set; }

    public void Enter(IState state)
    {
      ChangeState(state);
      state.Enter();
    }

    private void ChangeState(IState state)
    {
      ActiveState?.Exit();
      ActiveState = state;
    }

    // public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    // {
    //   var state = ChangeState<TState>();
    //   state.Enter(payload);
    // }
    //
    // public void Enter<TState, TPayload, TPayload2>(TPayload payload, TPayload2 payload2)
    //   where TState : class, IPayloadedState<TPayload, TPayload2>
    // {
    //   var state = ChangeState<TState>();
    //   state.Enter(payload, payload2);
    // }
  }
}