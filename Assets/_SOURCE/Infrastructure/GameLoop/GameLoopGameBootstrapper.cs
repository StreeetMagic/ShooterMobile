using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Maps;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameLoop
{
  public class GameLoopGameBootstrapper : MonoBehaviour
  {
    private PlayerFactory _playerFactory;
    private MapFactory _mapFactory;
    private CameraFactory _cameraFactory;
    private EnemySpawnerFactory _enemySpawnerFactory;

    [Inject]
    public void Construct(PlayerFactory playerFactory, MapFactory mapFactory, CameraFactory cameraFactory, 
      EnemySpawnerFactory enemySpawnerFactory)
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
    }

    void Start()
    {
      _mapFactory.Create(transform);
      _playerFactory.Create(transform);
      _cameraFactory.Create(transform);
      _enemySpawnerFactory.Create();
    }
  }
}