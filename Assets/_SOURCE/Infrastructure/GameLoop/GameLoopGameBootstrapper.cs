using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Maps;
using UnityEngine;
using Vlad.HeadsUpDisplays;
using Zenject;

namespace Infrastructure.GameLoop
{
  public class GameLoopGameBootstrapper : MonoBehaviour
  {
    private PlayerFactory _playerFactory;
    private MapFactory _mapFactory;
    private CameraFactory _cameraFactory;
    private EnemySpawnerFactory _enemySpawnerFactory;
    private HeadsUpDisplayFactory _headsUpDisplayFactory;

    [Inject]
    public void Construct
    (
      PlayerFactory playerFactory,
      MapFactory mapFactory,
      CameraFactory cameraFactory,
      EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory
    )
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
      _headsUpDisplayFactory = headsUpDisplayFactory;
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