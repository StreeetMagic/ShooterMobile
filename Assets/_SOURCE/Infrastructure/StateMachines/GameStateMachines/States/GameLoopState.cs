using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Maps;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Infrastructure.StateMachines.GameStateMachines.States
{
  public class GameLoopState : IGameState
  {
    private readonly PlayerFactory _playerFactory;
    private readonly MapFactory _mapFactory;
    private readonly CameraFactory _cameraFactory;
    private readonly EnemySpawnerFactory _enemySpawnerFactory;
    private readonly HeadsUpDisplayFactory _headsUpDisplayFactory;

    private Transform _sceneTransform;

    public GameLoopState(PlayerFactory playerFactory, MapFactory mapFactory,
      CameraFactory cameraFactory, EnemySpawnerFactory enemySpawnerFactory,
      HeadsUpDisplayFactory headsUpDisplayFactory)
    {
      _playerFactory = playerFactory;
      _mapFactory = mapFactory;
      _cameraFactory = cameraFactory;
      _enemySpawnerFactory = enemySpawnerFactory;
      _headsUpDisplayFactory = headsUpDisplayFactory;
    }

    public void Enter()
    {
      _sceneTransform = GameObject.FindObjectOfType<GameLoopInstaller>().transform;

      _mapFactory.Create(_sceneTransform);
       _playerFactory.Create(_sceneTransform);
      _cameraFactory.Create(_sceneTransform);
      _enemySpawnerFactory.Create();
      _headsUpDisplayFactory.Create(_sceneTransform);
    }

    public void Exit()
    {
    }
  }
}