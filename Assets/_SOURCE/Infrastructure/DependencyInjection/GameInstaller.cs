using Cameras;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.RewardServices;
using Infrastructure.Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.CoroutineRunners;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StateMachines;
using Infrastructure.Services.StateMachines.GameStateMachines.States;
using Infrastructure.Services.StaticDataServices;
using Infrastructure.Services.ZenjectFactory;
using Inputs;
using Maps;
using Vlad.HeadsUpDisplays;
using Zenject;

namespace Infrastructure.DependencyInjection
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      CoroutineRunner();

      ZenjectFactory();

      GameStateMachine();

      Input();

      AssetProvider();

      CurrentDataService();

      StaticDataService();

      LoadingCurtain();

      PlayerProvider();

      PlayerFactory();

      MapFactory();

      CameraFactory();

      EnemySpawnerFactory();

      RewardService();

      HeadsUpDisplayFactory();
    }

    private void HeadsUpDisplayFactory() =>
      Container
        .Bind<HeadsUpDisplayFactory>()
        .AsSingle();

    private void RewardService() =>
      Container
        .Bind<RewardService>()
        .AsSingle()
        .NonLazy();

    private void EnemySpawnerFactory() =>
      Container
        .Bind<EnemySpawnerFactory>()
        .AsSingle()
        .NonLazy();

    private void CameraFactory() =>
      Container
        .Bind<CameraFactory>()
        .AsSingle()
        .NonLazy();

    private void MapFactory() =>
      Container
        .Bind<MapFactory>()
        .AsSingle()
        .NonLazy();

    private void PlayerFactory() =>
      Container
        .Bind<PlayerFactory>()
        .AsSingle()
        .NonLazy();

    private void PlayerProvider() =>
      Container
        .BindInterfacesAndSelfTo<PlayerProvider>()
        .AsSingle();

    private void LoadingCurtain() =>
      Container
        .Bind<LoadingCurtain.LoadingCurtain>()
        .FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.LoadingCurtain)
        .AsSingle();

    private void ZenjectFactory() =>
      Container
        .Bind<IZenjectFactory>()
        .To<ZenjectFactory>()
        .AsSingle();

    private void CoroutineRunner() =>
      Container
        .Bind<ICoroutineRunner>()
        .To<CoroutineRunner>()
        .FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.CoroutineRunner)
        .AsSingle();

    private void StaticDataService() =>
      Container
        .Bind<IStaticDataService>()
        .To<StaticDataService>()
        .AsSingle();

    private void CurrentDataService() =>
      Container
        .Bind<PersistentProgressService>()
        .AsSingle();

    private void AssetProvider() =>
      Container
        .Bind<IAssetProvider>()
        .To<AssetProvider>()
        .AsSingle();

    private void Input() =>
      Container
        .Bind<IInputService>()
        .To<InputService>()
        .AsSingle();

    private void GameStateMachine() =>
      Container
        .Bind<IStateMachine<IGameState>>()
        .To<StateMachine<IGameState>>()
        .AsSingle();
  }
}