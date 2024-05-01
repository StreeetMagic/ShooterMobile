using System;
using Configs.Resources.QuestConfigs.Scripts;
using DataRepositories;
using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.UserIntefaces;
using Inputs;
using Loggers;
using Zenject;

namespace Infrastructure.DebugServices
{
  public class DebugService : IInitializable, IDisposable
  {
    private readonly IInputService _inputService;
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SaveLoadService _saveLoadService;
    private readonly WindowService _windowService;
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly DebugLogger _logger;

    public DebugService(IInputService inputService,
      IStateMachine<IGameState> gameStateMachine, SaveLoadService saveLoadService,
      WindowService windowService, ExpierienceStorage expierienceStorage, DebugLogger logger)
    {
      _inputService = inputService;
      _gameStateMachine = gameStateMachine;
      _saveLoadService = saveLoadService;
      _windowService = windowService;
      _expierienceStorage = expierienceStorage;
      _logger = logger;
    }

    public void Initialize()
    {
      _inputService.Restart += Restart;
      _inputService.DeleteSaves += DeleteSaves;
      _inputService.OpenQuestWindow += OpenQuest;
      _inputService.AddExpierience += AddExpierience;
    }

    public void Dispose()
    {
      _inputService.Restart -= Restart;
      _inputService.DeleteSaves -= DeleteSaves;
      _inputService.OpenQuestWindow -= OpenQuest;
      _inputService.AddExpierience -= AddExpierience;
    }

    public void Restart()
    {
      _gameStateMachine.Enter<LoadLevelState, string, string>(Constants.Scenes.Empty, Constants.Scenes.GameLoop);
    }

    public void DeleteSaves()
    {
      _saveLoadService.DeleteSaves();
    }

    private void OpenQuest()
    {
      _windowService.Create(WindowId.Quest, QuestId.Quest1);
    }

    private void AddExpierience()
    {
      _expierienceStorage.AllPoints.Value += 60;
    }
  }
}