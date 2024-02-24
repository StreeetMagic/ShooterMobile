using Infrastructure.Services.StateMachines;
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

      BindPlayerFactory();
    }

    private void BindPlayerFactory() =>
      Container
        .Bind<PlayerFactory>()
        .AsSingle()
        .NonLazy();
  }
}