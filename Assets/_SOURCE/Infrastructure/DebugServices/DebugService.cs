using System;
using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.UserIntefaces;
using Inputs;
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

    public DebugService(IInputService inputService,
      IStateMachine<IGameState> gameStateMachine, SaveLoadService saveLoadService,
      WindowFactory windowFactory)
    {
      _inputService = inputService;
      _gameStateMachine = gameStateMachine;
      _saveLoadService = saveLoadService;
      _windowFactory = windowFactory;
    }

    public void Initialize()
    {
      _inputService.Restart += Restart;
      _inputService.DeleteSaves += DeleteSaves;
      _inputService.OpenQuestWindow += OpenQuestWindow;
    }

    public void Dispose()
    {
      _inputService.Restart -= Restart;
      _inputService.DeleteSaves -= DeleteSaves;
      _inputService.OpenQuestWindow -= OpenQuestWindow;
    }

    public void Restart()
    {
      _gameStateMachine.Enter<LoadLevelState, string, string>(Constants.Scenes.Empty, Constants.Scenes.GameLoop);
    }

    public void DeleteSaves()
    {
      _saveLoadService.DeleteSaves();
    }

    public void OpenQuestWindow()
    {
      _windowFactory.Create(WindowId.Quest);
    }
  }
}