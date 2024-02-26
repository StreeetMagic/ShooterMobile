using _SOURCE.Cameras;
using _SOURCE.Maps;
using Infrastructure.Services.StateMachines;
using Players;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Infrastructure.DIC.GameLoopSceneContext
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
        .BindInterfacesAndSelfTo<PlayerInputHandler>()
        .AsSingle();
    }
  }
}