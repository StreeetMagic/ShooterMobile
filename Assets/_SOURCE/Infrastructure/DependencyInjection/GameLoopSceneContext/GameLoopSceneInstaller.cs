using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Infrastructure.GameLoop;
using Maps;
using UnityEngine;
using Zenject;

namespace Infrastructure.DependencyInjection.GameLoopSceneContext
{
  public class GameLoopSceneInstaller : MonoInstaller
  {
    [SerializeField] private GameLoopGameBootstrapper _gameLoopGameBootstrapper;

    public override void InstallBindings()
    {
      NewMethod();

      Container
        .Bind<GameLoopGameBootstrapper>()
        .FromInstance(_gameLoopGameBootstrapper)
        .AsSingle()
        .NonLazy();

      NewMethod1();

      Container
        .Bind<MapFactory>()
        .AsSingle()
        .NonLazy();

      Container
        .Bind<CameraFactory>()
        .AsSingle()
        .NonLazy();

      Container
        .Bind<EnemySpawnerFactory>()
        .AsSingle()
        .NonLazy();
    }

    private void NewMethod1()
    {
      Container
        .Bind<PlayerFactory>()
        .AsSingle()
        .NonLazy();

      Debug.Log(" Биндим фабрику ");
    }

    private void NewMethod()
    {
      Container
        .Bind<PlayerProvider>()
        .AsSingle();

      Debug.Log(" Биндим провайдер");
    }
  }
}