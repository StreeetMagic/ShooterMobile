using System;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.UserIntefaces;
using Inputs;
using Loggers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Spawners.DebugServices
{
  public class DebugService : IInitializable, IDisposable
  {
    private readonly IInputService _inputService;
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly SaveLoadService _saveLoadService;
    private readonly WindowFactory _windowFactory;
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly DebugLogger _logger;

    public DebugService(IInputService inputService,
      IStateMachine<IGameState> gameStateMachine, SaveLoadService saveLoadService,
      WindowFactory windowFactory, ExpierienceStorage expierienceStorage, DebugLogger logger)
    {
      _inputService = inputService;
      _gameStateMachine = gameStateMachine;
      _saveLoadService = saveLoadService;
      _windowFactory = windowFactory;
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
      _windowFactory.Create(WindowId.Quest, QuestId.Quest1);
    }

    private void AddExpierience()
    {
      _expierienceStorage.AllPoints.Value += 60;

      _logger.Log("Expierience: " + _expierienceStorage.AllPoints.Value);
    }
  }
}