using System;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.UserIntefaces;
using Inputs;
using Quests;
using Zenject;

namespace Infrastructure.DebugServices
{
  public class DebugService : IInitializable, IDisposable
  {
    private readonly InputService _inputService;
    private readonly SaveLoadService _saveLoadService;
    private readonly WindowService _windowService;
    private readonly GameLoopInitializer _gameLoopInitializer;

    public DebugService(InputService inputService, SaveLoadService saveLoadService,
      WindowService windowService, GameLoopInitializer gameLoopInitializer)
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