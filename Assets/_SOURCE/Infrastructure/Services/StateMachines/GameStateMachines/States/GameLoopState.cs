using Infrastructure.Services.CurrentDatas;
using Infrastructure.Services.StateMachines.GameLoopStateMachines.States;
using Infrastructure.Services.StaticDataServices;
using Infrastructure.Services.ZenjectFactory;

namespace Infrastructure.Services.StateMachines.GameStateMachines.States
{
  public class GameLoopState : IGameState
  {
    private readonly ICurrentDataService _currentDataService;
    private readonly IStateMachine<IGameLoopState> _gameLoopStateMachine;
    private readonly IStaticDataService _staticDataService;
    private readonly IZenjectFactory _zenjectFactory;

    public GameLoopState(IStateMachine<IGameLoopState> gameLoopStateMachine,
      ICurrentDataService currentDataService, IZenjectFactory zenjectFactory, IStaticDataService staticDataService)
    {
      _gameLoopStateMachine = gameLoopStateMachine;
      _currentDataService = currentDataService;
      _zenjectFactory = zenjectFactory;
      _staticDataService = staticDataService;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}