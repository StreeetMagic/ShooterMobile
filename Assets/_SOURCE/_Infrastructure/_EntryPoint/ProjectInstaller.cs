using AssetProviders;
using AudioServices;
using CoroutineRunners;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using CurrencyRepositories.Expirience;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Quests;
using Gameplay.RewardServices;
using Gameplay.Upgrades;
using Inputs;
using LoadingCurtains;
using Loggers;
using PersistentProgresses;
using Projects;
using RandomServices;
using SaveLoadServices;
using SceneLoaders;
using StaticDataServices;
using Zenject.Source.Install;
using ZenjectFactories;

namespace _EntryPoint
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
    }
  }
}