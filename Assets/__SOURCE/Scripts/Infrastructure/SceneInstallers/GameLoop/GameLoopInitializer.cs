using Cameras;
using Characters.Pets.Hens;
using Characters.Players;
using Characters.Players._components;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using DG.Tweening;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Quests;
using Scripts;
using Spawners.SpawnerFactories;
using UnityEngine;
using Upgrades;
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
      Time.timeScale = 1f;

      _mapFactory.Create(_gameLoopInstaller.transform);
      _playerFactory.Create(_gameLoopInstaller.transform);
      _cameraFactory.Create(_gameLoopInstaller.transform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(_gameLoopInstaller.transform);
      _playerStatsProvider.Start();

      _saveLoadService.LoadProgress();
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