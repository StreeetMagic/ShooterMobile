using Infrastructure.Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.CoroutineRunners;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StateMachines;
using Infrastructure.Services.StateMachines.GameStateMachines.States;
using Infrastructure.Services.StaticDataServices;
using Infrastructure.Services.ZenjectFactory;
using Inputs;
using Zenject;

namespace Infrastructure.DependencyInjection
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindCoroutineRunner();
      BindZenjectFactory();

      BindGameStateMachine();

      BindInput();
      BindAssetProvider();
      BindCurrentDataService();
      BindStaticDataService();

      BindLoadingCurtain();
    }

    private void BindLoadingCurtain() =>
      Container
        .Bind<LoadingCurtain.LoadingCurtain>()
        .FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.LoadingCurtain)
        .AsSingle();

    private void BindZenjectFactory() =>
      Container
        .Bind<IZenjectFactory>()
        .To<ZenjectFactory>()
        .AsSingle();

    private void BindCoroutineRunner() =>
      Container
        .Bind<ICoroutineRunner>()
        .To<CoroutineRunner>()
        .FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.CoroutineRunner)
        .AsSingle();

    private void BindStaticDataService() =>
      Container
        .Bind<IStaticDataService>()
        .To<StaticDataService>()
        .AsSingle();

    private void BindCurrentDataService() =>
      Container
        .Bind<IPersistentProgressService>()
        .To<PersistentProgressService>()
        .AsSingle();

    private void BindAssetProvider() =>
      Container
        .Bind<IAssetProvider>()
        .To<AssetProvider>()
        .AsSingle();

    private void BindInput() =>
      Container
        .Bind<IInputService>()
        .To<InputService>()
        .AsSingle();

    private void BindGameStateMachine() =>
      Container
        .Bind<IStateMachine<IGameState>>()
        .To<StateMachine<IGameState>>()
        .AsSingle();
  }
}