using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Maps;
using UnityEngine;
using Vlad.BaseTriggers;
using Vlad.HeadsUpDisplays;
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

    [Inject]
    public void Construct
    (
      PlayerFactory playerFactory,
      MapFactory mapFactory,
      CameraFactory cameraFactory,
      EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory,
      BaseTriggerFactory baseTriggerFactory
    )
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
      _headsUpDisplayFactory = headsUpDisplayFactory;
      _baseTriggerFactory = baseTriggerFactory;
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