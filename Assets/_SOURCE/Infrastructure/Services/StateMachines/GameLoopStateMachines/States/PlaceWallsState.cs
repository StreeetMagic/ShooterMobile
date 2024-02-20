using System;
using System.Collections.Generic;
using Infrastructure.Services.CurrentDatas;
using Infrastructure.Services.StateMachines.States;

namespace Infrastructure.Services.StateMachines.GameLoopStateMachines.States
{
  public class PlaceWallsState : IGameLoopState
  {
    private readonly ICurrentDataService _currentDataService;
    private readonly IStateMachine<IGameLoopState> _gameLoopStateMachine;

    public PlaceWallsState(IStateMachine<IGameLoopState> gameLoopStateMachine, ICurrentDataService currentDataService)
    {
      _gameLoopStateMachine = gameLoopStateMachine;

      _currentDataService = currentDataService;
    }

    public event Action<IState> Entered;

    public void Enter()
    {
      Entered?.Invoke(this);
    }

    public void Exit()
    {
    }
  }
}