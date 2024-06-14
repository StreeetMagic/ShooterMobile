using Cameras;
using DG.Tweening;
using Gameplay.Characters.Pets.Hens;
using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Quests;
using Gameplay.Spawners.SpawnerFactories;
using Gameplay.Upgrades;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Maps;
using Scenes._Infrastructure.Scripts;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInitializer : MonoBehaviour
  {
    public SceneId SceneId;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private GameLoopInstaller _gameLoopInstaller;
    [Inject] private PlayerFactory _playerFactory;
    [Inject] private MapFactory _mapFactory;
    [Inject] private CameraFactory _cameraFactory;
    [Inject] private EnemySpawnerFactory _enemySpawnerFactory;
    [Inject] private HeadsUpDisplayFactory _headsUpDisplayFactory;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;
    [Inject] private UpgradeService _upgradeService;
    [Inject] private AudioService _audioService;
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private ICoroutineRunner _runner;
    [Inject] private QuestStorage _questStorage;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private HenSpawner _henSpawner;

    private void Start()
    {
      _saveLoadService.LoadProgress();

      Time.timeScale = 1f;

      _playerStatsProvider.Start();

      _mapFactory.Create(_gameLoopInstaller.transform);
      _playerFactory.Create(_gameLoopInstaller.transform);
      _cameraFactory.Create(_gameLoopInstaller.transform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(_gameLoopInstaller.transform);

      _backpackStorage.Clean();
    }

    public void Restart()
    {
      Destroy();
      EnterScene();
    }

    private void EnterScene()
    {
      _sceneLoader.Load(SceneId);
    }

    private void Destroy()
    {
      _runner.StopAllCoroutines();
      DOTween.KillAll();
      Time.timeScale = 0f;

      _playerStatsProvider.Stop();

      _henSpawner.DeSpawnAll();
      _headsUpDisplayFactory.Destroy();
      _enemySpawnerFactory.Destroy();
      _playerFactory.Destroy();
      _mapFactory.Destroy();
    }

    // private void LogScenes()
    // {
    //   List<SceneId> sceneList = _sceneLoader.LoadedScenes;
    //
    //   var scenes = "";
    //
    //   foreach (SceneId scene in sceneList)
    //     scenes += scene + " ";
    //
    //   Debug.Log(scenes);
    // }
  }
}