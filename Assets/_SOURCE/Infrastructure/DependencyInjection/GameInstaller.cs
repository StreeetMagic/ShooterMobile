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
using Infrastructure.CoroutineRunners;
using Infrastructure.DataRepositories;
using Infrastructure.Games;
using Infrastructure.LoadingCurtains;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.StaticDataServices;
using Infrastructure.UserIntefaces;
using Infrastructure.ZenjectFactories;
using Inputs;
using Maps;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Zenject;

namespace Infrastructure.DependencyInjection
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<ZenjectFactory>().AsSingle();
      Container.Bind<LoadingCurtain>().FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.LoadingCurtain).AsSingle();

      Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefabResource(Constants.AssetsPath.Prefabs.CoroutineRunner).AsSingle();
      Container.Bind<IStateMachine<IGameState>>().To<StateMachine<IGameState>>().AsSingle();

      Container.Bind<IInputService>().To<InputService>().AsSingle();
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<SaveLoadService>().AsSingle();
      Container.Bind<UpgradeService>().AsSingle();
      Container.Bind<PersistentProgressService>().AsSingle();

      Container.Bind<EggsInBankStorage>().AsSingle();
      Container.Bind<MoneyInBankStorage>().AsSingle();
      Container.Bind<ExpierienceStorage>().AsSingle();

      Container.Bind<HeadsUpDisplayProvider>().AsSingle();
      Container.Bind<PlayerProvider>().AsSingle();
      Container.Bind<MapProvider>().AsSingle();
      Container.Bind<PlayerStatsProvider>().AsSingle();
      Container.Bind<CameraProvider>().AsSingle();

      Container.Bind<VisualEffectFactory>().AsSingle();
      Container.Bind<WindowFactory>().AsSingle();
      Container.Bind<RandomService>().AsSingle();

      Container.BindInterfacesAndSelfTo<CorpseRemover>().AsSingle();

      Container.Bind<ProjectileFactory>().AsSingle();

      Container.Bind<ProjectileStorage>().AsSingle();
      Container.Bind<BackpackStorage>().AsSingle().NonLazy();
      Container.Bind<LootSlotFactory>().AsSingle();
      Container.Bind<EnemyLootSlotFactory>().AsSingle();
      Container.Bind<RewardService>().AsSingle();
    }
  }
}