using System.Collections.Generic;
using Cameras;
using Characters.Enemies;
using Characters.Enemies._components.ActorUserInterfaces.LootSlots;
using Characters.Enemies.Configs;
using Characters.Pets.Hens;
using Characters.Players;
using Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers;
using CorpseRemovers;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.DebugServices;
using Infrastructure.UserIntefaces;
using Infrastructure.VisualEffects;
using Infrastructure.VisualEffects.ParticleImages;
using Infrastructure.ZenjectFactories.SceneContext;
using Projectiles.Scripts;
using Quests;
using Quests.Subquests;
using Spawners;
using Spawners.SpawnerFactories;
using Spawners.SpawnPoints;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays._components.LootSlotsUpdaters;
using UserInterface.Windows.QuestWindows;
using UserInterface.Windows.QuestWindows._components.SubQuestSlots;
using UserInterface.Windows.ShopWinsows.UpgradeShopWindows;
using Zenject;
using Zenject.Source.Install;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInstaller : MonoInstaller
  {
    public Map Map;

    [Inject] private ArtConfigProvider _artConfigProvider;

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
      Container.BindInterfacesAndSelfTo<UpgradeCellFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectileStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<LootSlotFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyLootSlotFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<CorpseRemover>().AsSingle();
      Container.BindInterfacesAndSelfTo<ProjectileFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle();

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
       // .ByNewContextPrefab<QuestWindowInstaller>(_assetProvider.Get<QuestWindow>().GetComponent<QuestWindowInstaller>())
        .ByNewContextPrefab<QuestWindowInstaller>(_artConfigProvider.GetPrefab(PrefabId.QuestWindow).GetComponent<QuestWindowInstaller>())
        .AsSingle();

      Container.BindFactory<SubQuest, SubQuestSlot, SubQuestSlot.Factory>()
        .FromSubContainerResolve()
       // .ByNewContextPrefab<SubQuestSlotInstaller>(_assetProvider.Get<SubQuestSlot>().GetComponent<SubQuestSlotInstaller>())
        .ByNewContextPrefab<SubQuestSlotInstaller>(_artConfigProvider.GetPrefab(PrefabId.SubQuestSlot).GetComponent<SubQuestSlotInstaller>()) 
        .AsSingle();

      Container.BindFactory<EnemyConfig, List<SpawnPoint>, EnemySpawner, Enemy, Enemy.Factory>()
        .FromSubContainerResolve()
        //.ByNewContextPrefab<EnemyInstaller>(_assetProvider.Get<Enemy>().GetComponent<EnemyInstaller>())
        .ByNewContextPrefab<EnemyInstaller>(_artConfigProvider.GetPrefab(PrefabId.Enemy).GetComponent<EnemyInstaller>()) 
        .AsSingle();

      Container.BindFactory<Quest, QuestConfig, QuestPointer, QuestPointer.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<QuestPointerInstaller>(_artConfigProvider.GetPrefab(PrefabId.QuestPointer).GetComponent<QuestPointerInstaller>()) 
        //.ByNewContextPrefab<QuestPointerInstaller>(_assetProvider.Get<QuestPointer>().GetComponent<QuestPointerInstaller>())
        .AsSingle();
    }
  }
}