using Gameplay.Characters.Players;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.CurrencyRepositories.Expirience;
using Gameplay.Quests;
using Gameplay.RewardServices;
using Gameplay.Upgrades;
using Infrastructure.AssetProviders;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.LoadingCurtains;
using Infrastructure.PersistentProgresses;
using Infrastructure.Projects;
using Infrastructure.RandomServices;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using Inputs;
using Loggers;
using Zenject.Source.Install;

namespace Infrastructure.EntryPoint
{
  public class ProjectInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<ProjectInitializer>().FromInstance(GetComponent<ProjectInitializer>()).AsSingle().NonLazy();
      Container.Bind<ProjectZenjectFactory>().AsSingle();
      Container.Bind<LoadingCurtain>().FromComponentInNewPrefabResource(ProjectConstants.AssetsPath.Prefabs.LoadingCurtain).AsSingle();

      Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(ProjectConstants.AssetsPath.Prefabs.CoroutineRunner).AsSingle();

      Container.Bind<IInputService>().To<InputService>().AsSingle();
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<SaveLoadService>().AsSingle();

      Container.Bind<PersistentProgressService>().AsSingle();

      Container.BindInterfacesAndSelfTo<EggsInBankStorage>().AsSingle();
      Container.Bind<MoneyInBankStorage>().AsSingle();
      Container.Bind<ExpierienceStorage>().AsSingle().NonLazy();
      Container.Bind<QuestStorage>().AsSingle();

      Container.BindInterfacesAndSelfTo<RewardService>().AsSingle();

      Container.Bind<RandomService>().AsSingle();

      Container.Bind<SceneLoader>().AsSingle();
      Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
      Container.Bind<DebugLogger>().AsSingle();

      Container.BindInterfacesAndSelfTo<BackpackStorage>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerStatsProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<UpgradeService>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectData>().AsSingle();
    }
  }
}