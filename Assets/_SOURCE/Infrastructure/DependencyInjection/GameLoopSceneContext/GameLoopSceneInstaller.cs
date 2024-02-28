using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.PlayerFactories;
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
      Container
        .Bind<GameLoopGameBootstrapper>()
        .FromInstance(_gameLoopGameBootstrapper)
        .AsSingle();

      Container
        .Bind<PlayerFactory>()
        .AsSingle()
        .NonLazy();

      Container
        .Bind<MapFactory>()
        .AsSingle();

      Container
        .Bind<CameraFactory>()
        .AsSingle()
        .NonLazy();

      Container
        .Bind<EnemySpawnerFactory>()
        .AsSingle();

      Container
        .BindInterfacesAndSelfTo<PlayerInputHandler>()
        .AsSingle();

      Container
        .BindInterfacesAndSelfTo<TargetHolder>()
        .AsSingle()
        .NonLazy();
    }
  }
}