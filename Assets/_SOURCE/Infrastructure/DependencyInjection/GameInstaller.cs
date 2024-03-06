using Cameras;
using CodeBase.UI.Services.Windows;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.RewardServices;
using Infrastructure.AssetProviders;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.LoadingCurtains;
using Infrastructure.PersistentProgresses;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using Inputs;
using Maps;
using Vlad.BaseTriggers;
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

      BaseTriggerFactory();

      WindowFactory();

      HeadsUpDisplayProvider();

      DataRepository();
    }

    private void DataRepository() =>
      Container
        .Bind<DataRepository>()
        .AsSingle();

    private void HeadsUpDisplayProvider() =>
      Container
        .Bind<HeadsUpDisplayProvider>()
        .AsSingle();

    private void WindowFactory() =>
      Container
        .Bind<WindowFactory>()
        .AsSingle();

    private void BaseTriggerFactory() =>
      Container
        .Bind<BaseTriggerFactory>()
        .AsSingle();

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
        .Bind<LoadingCurtain>()
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