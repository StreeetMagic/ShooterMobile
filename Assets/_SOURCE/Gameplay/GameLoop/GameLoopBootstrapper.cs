using Cameras;
using Gameplay.BaseTriggers;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.Upgrades;
using Maps;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameLoopBootstrapper : MonoBehaviour
  {
    private PlayerFactory _playerFactory;
    private MapFactory _mapFactory;
    private CameraFactory _cameraFactory;
    private EnemySpawnerFactory _enemySpawnerFactory;
    private HeadsUpDisplayFactory _headsUpDisplayFactory;
    private BaseTriggerFactory _baseTriggerFactory;
    private UpgradeService _upgradeService;

    [Inject]
    public void Construct
    (
      PlayerFactory playerFactory,
      MapFactory mapFactory,
      CameraFactory cameraFactory,
      EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory,
      BaseTriggerFactory baseTriggerFactory,
      UpgradeService upgradeService
    )
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
      _headsUpDisplayFactory = headsUpDisplayFactory;
      _baseTriggerFactory = baseTriggerFactory;
      _upgradeService = upgradeService;
    }

    void Start()
    {
      _mapFactory.Create(transform);
      _playerFactory.Create(transform);
      _cameraFactory.Create(transform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(transform);
    }
  }
}