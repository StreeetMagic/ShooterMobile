using Gameplay.Characters.Enemies;
using Zenject;

namespace PUNBALL.Infrastructure.StateMachine
{
  public abstract class StateMachine : ITickable
  {
    private EnemyStatesProvider _enemyStatesProvider;

    protected StateMachine(EnemyStatesProvider enemyStatesProvider)
    {
      _enemyStatesProvider = enemyStatesProvider;
    }

    public IExitableState ActiveState { get; protected set; }

    public void Enter<T>() where T : class, IState
    {
      var state = _enemyStatesProvider.GetState<T>();
      ChangeState(state);
      state.Enter();
    }

    public void Tick()
    {
      if (ActiveState != null)
      {
        if (ActiveState is ITickable tickable)
        {
          tickable.Tick();
        }
      }
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