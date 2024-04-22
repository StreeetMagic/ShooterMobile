using Cameras;
using Gameplay.BaseTriggers;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Characters.Players.Factories;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Gameplay.Upgrades;
using Infrastructure.AssetProviders;
using Infrastructure.AudioServices;
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.LoadingCurtains;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.SceneLoaders;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.StaticDataServices;
using Infrastructure.UserIntefaces;
using Infrastructure.ZenjectFactories;
using Inputs;
using Loggers;
using Maps;
using Quests;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Zenject;

namespace Infrastructure.DependencyInjection
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<ProjectZenjectFactory>().AsSingle();
      Container.Bind<LoadingCurtain>().FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.LoadingCurtain).AsSingle();

      Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.CoroutineRunner).AsSingle();
      Container.BindInterfacesAndSelfTo<StateMachine<IGameState>>().AsSingle();

      Container.Bind<IInputService>().To<InputService>().AsSingle();
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<SaveLoadService>().AsSingle();

      Container.Bind<PersistentProgressService>().AsSingle();

      Container.BindInterfacesAndSelfTo<EggsInBankStorage>().AsSingle();
      Container.Bind<MoneyInBankStorage>().AsSingle();
      Container.Bind<ExpierienceStorage>().AsSingle().NonLazy();
      Container.Bind<QuestStorage>().AsSingle();
      Container.Bind<QuestCompleter>().AsSingle();
      Container.BindInterfacesAndSelfTo<RewardService>().AsSingle();

      Container.Bind<RandomService>().AsSingle();

      Container.Bind<SceneLoader>().AsSingle();
      Container.BindInterfacesAndSelfTo<AudioService>().AsSingle();
      Container.Bind<DebugLogger>().AsSingle();
      
      Container.BindInterfacesAndSelfTo<BackpackStorage>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerStatsProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<UpgradeService>().AsSingle();
    }
  }
}