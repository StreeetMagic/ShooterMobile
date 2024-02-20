using System;
using Infrastructure.Services.CurrentDatas;
using Infrastructure.Services.StaticDataServices;
using Infrastructure.Services.ZenjectFactory;

namespace Infrastructure.Services.StateMachines.GameLoopStateMachines.States
{
  public class ChooseTowerState : IGameLoopState
  {
    private readonly ICurrentDataService _currentDataService;
    private readonly IStaticDataService _staticDataService;
    private readonly IZenjectFactory _zenjectFactory;

    public ChooseTowerState(ICurrentDataService currentDataService,
      IStaticDataService staticDataService, IZenjectFactory zenjectFactory)
    {
      _currentDataService = currentDataService;
      _staticDataService = staticDataService;
      _zenjectFactory = zenjectFactory;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}