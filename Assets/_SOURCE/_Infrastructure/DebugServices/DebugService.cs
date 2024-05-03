using System;
using Configs.Resources.QuestConfigs.Scripts;
using DataRepositories;
using Infrastructure.Games;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.UserIntefaces;
using Inputs;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.DebugServices
{
  public class DebugService : IInitializable, IDisposable
  {
    private readonly IInputService _inputService;
    private readonly SaveLoadService _saveLoadService;
    private readonly WindowService _windowService;
    private readonly ExpierienceStorage _expierienceStorage;
    private readonly SceneLoader _sceneLoader;


    public DebugService(IInputService inputService, SaveLoadService saveLoadService,
      WindowService windowService, ExpierienceStorage expierienceStorage, SceneLoader sceneLoader 
      )
    {
      _inputService = inputService;
      _saveLoadService = saveLoadService;
      _windowService = windowService;
      _expierienceStorage = expierienceStorage;
      _sceneLoader = sceneLoader;

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
      Object.FindObjectOfType<GameLoopBootstrapper>().Destroy();
      _sceneLoader.Load(ProjectConstants.Scenes.Empty, () => _sceneLoader.Load(ProjectConstants.Scenes.GameLoop));
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