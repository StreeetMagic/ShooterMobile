using Cameras;
using Gameplay.BaseTriggers;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.DebugServices;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Players.Factories;
using Gameplay.CorpseRemovers;
using Infrastructure.UserIntefaces;
using Infrastructure.ZenjectFactories;
using Maps;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Zenject;

public class GameLoopInstaller : MonoInstaller
{
  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<GameLoopZenjectFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<MapFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemySpawnerFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<HeadsUpDisplayFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<BaseTriggerFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<UpgradeCellFactory>().AsSingle();

    Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<ProjectileStorage>().AsSingle();

    Container.BindInterfacesAndSelfTo<LootSlotFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemyLootSlotFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<CorpseRemover>().AsSingle();

    Container.BindInterfacesAndSelfTo<ProjectileFactory>().AsSingle();
    Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();

    Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();
    Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle();
    Container.BindInterfacesAndSelfTo<VisualEffectFactory>().AsSingle();

    Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
    Container.BindInterfacesAndSelfTo<HeadsUpDisplayProvider>().AsSingle();

    Container.BindInterfacesAndSelfTo<DebugService>().AsSingle();
  }
}