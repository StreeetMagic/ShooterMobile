using System;
using _Infrastructure.SaveLoadServices;
using _Infrastructure.SceneInstallers.GameLoop;
using _Infrastructure.UserIntefaces;
using Gameplay.Quests;
using Inputs;
using Zenject;

namespace _Infrastructure.DebugServices
{
  public class DebugService : IInitializable, IDisposable
  {
    private readonly IInputService _inputService;
    private readonly SaveLoadService _saveLoadService;
    private readonly WindowService _windowService;
    private readonly IGameLoopInitializer _gameLoopInitializer;

    public DebugService(IInputService inputService, SaveLoadService saveLoadService,
      WindowService windowService, IGameLoopInitializer gameLoopInitializer)
    {
      _inputService = inputService;
      _saveLoadService = saveLoadService;
      _windowService = windowService;
      _gameLoopInitializer = gameLoopInitializer;
    }

    public void Initialize()
    {
      _inputService.Restart += Restart;
      _inputService.DeleteSaves += DeleteSaves;
      _inputService.OpenQuestWindow += OpenQuest;
    }

    public void Dispose()
    {
      _inputService.Restart -= Restart;
      _inputService.DeleteSaves -= DeleteSaves;
      _inputService.OpenQuestWindow -= OpenQuest;
    }

    public void Restart()
    {
      _gameLoopInitializer.Restart();
    }

    public void DeleteSaves()
    {
      _saveLoadService.DeleteSaves();
    }

    private void OpenQuest()
    {
      _windowService.Create(WindowId.Quest, QuestId.Quest1);
    }
  }
}