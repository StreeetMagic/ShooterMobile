using System.Collections.Generic;
using Cameras;
using Gameplay.BaseTriggers;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots;
using Gameplay.Characters.Pets.Hens;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.ActorUserIntefaces.QuestPointerSpawners.QuestPointers;
using Gameplay.CorpseRemovers;
using Gameplay.Projectiles.Scripts;
using Gameplay.Quests;
using Gameplay.Quests.Subquests;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnerFactories;
using Gameplay.Spawners.SpawnPoints;
using Gameplay.WeaponShops;
using Infrastructure.AssetProviders;
using Infrastructure.DebugServices;
using Infrastructure.UserIntefaces;
using Infrastructure.VisualEffects;
using Infrastructure.VisualEffects.ParticleImages;
using Infrastructure.ZenjectFactories.SceneContext;
using Maps;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays.Windows.QuestWindows;
using UserInterface.HeadsUpDisplays.Windows.QuestWindows._components.SubQuestSlots;
using UserInterface.HeadsUpDisplays.Windows.Shops.UpgradeShopWindows;
using Zenject;
using Zenject.Source.Install;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInstaller : MonoInstaller
  {
    public Map Map;

    [Inject] private AssetProvider _assetProvider;

    public override void InstallBindings()
    {
      Container.Bind<GameLoopInitializer>().FromInstance(GetComponent<GameLoopInitializer>()).AsSingle().NonLazy();
      Container.Bind<GameLoopInstaller>().FromInstance(this).AsSingle();

      Container.BindInterfacesAndSelfTo<DebugService>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<GameLoopZenjectFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<MapFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<HenFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<HenSpawner>().AsSingle();
      Container.BindInterfacesAndSelfTo<CameraFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemySpawnerFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<HeadsUpDisplayFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<BaseTriggerFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<UpgradeCellFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectileStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<LootSlotFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyLootSlotFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<CorpseRemover>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectileFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<WeaponShop>().AsSingle();

      Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle();
      Container.Resolve<MapProvider>().Map = Map;
      Map.Setup();

      Container.BindInterfacesAndSelfTo<VisualEffectFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<ParticleImageFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
      Container.BindInterfacesAndSelfTo<HeadsUpDisplayProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<QuestTargetsProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<SubQuestTargetsProvider>().AsSingle();

      Container.BindInterfacesAndSelfTo<QuestCompleter>().AsSingle();

      Container.BindFactory<Quest, QuestId, QuestWindow, QuestWindow.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<QuestWindowInstaller>(_assetProvider.Get<QuestWindow>().GetComponent<QuestWindowInstaller>())
        .AsSingle();

      Container.BindFactory<SubQuest, SubQuestSlot, SubQuestSlot.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<SubQuestSlotInstaller>(_assetProvider.Get<SubQuestSlot>().GetComponent<SubQuestSlotInstaller>())
        .AsSingle();

      Container.BindFactory<EnemyConfig, List<SpawnPoint>, EnemySpawner, Enemy, Enemy.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<EnemyInstaller>(_assetProvider.Get<Enemy>().GetComponent<EnemyInstaller>())
        .AsSingle();

      Container.BindFactory<Quest, QuestConfig, QuestPointer, QuestPointer.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<QuestPointerInstaller>(_assetProvider.Get<QuestPointer>().GetComponent<QuestPointerInstaller>())
        .AsSingle();
    }
  }
}