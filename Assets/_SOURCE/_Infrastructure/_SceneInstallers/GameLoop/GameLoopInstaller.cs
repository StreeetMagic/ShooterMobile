using System.Collections.Generic;
using Cameras;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.BaseTriggers;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Projectiles.Scripts;
using Gameplay.CorpseRemovers;
using Infrastructure.AssetProviders;
using Infrastructure.DebugServices;
using Infrastructure.UserIntefaces;
using Infrastructure.ZenjectFactories;
using Maps;
using Quests;
using Quests.Subquests;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays.QuestWindows;
using UserInterface.HeadsUpDisplays.QuestWindows.SubQuestSlots;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Zenject;
using Zenject.Source.Install;

namespace Infrastructure.DependencyInjection
{
  public class GameLoopInstaller : MonoInstaller
  {
    public GameLoopBootstrapper GameLoopBootstrapper;

    [Inject] private IAssetProvider _assetProvider;

    public override void InstallBindings()
    {
      Container.Bind<GameLoopInstaller>().FromInstance(this).AsSingle();

      Container.BindInterfacesAndSelfTo<GameLoopBootstrapper>().FromInstance(GetComponent<GameLoopBootstrapper>()).AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<DebugService>().AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<GameLoopZenjectFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<MapFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
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
      Container.BindInterfacesAndSelfTo<MapProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<VisualEffectFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<ParticleImageFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
      Container.BindInterfacesAndSelfTo<HeadsUpDisplayProvider>().AsSingle();

      Container.BindInterfacesAndSelfTo<QuestCompleter>().AsSingle();

      Container.BindFactory<Quest, QuestWindow, QuestWindow.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<QuestWindowInstaller>(_assetProvider.Get<QuestWindow>().GetComponent<QuestWindowInstaller>())
        .AsSingle();

      Container.BindFactory<SubQuest, SubQuestSlot, SubQuestSlot.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<SubQuestSlotInstaller>(_assetProvider.Get<SubQuestSlot>().GetComponent<SubQuestSlotInstaller>())
        .AsSingle();

      Container.BindFactory<EnemyConfig, List<SpawnPoint>, Transform, Enemy, Enemy.Factory>()
        .FromSubContainerResolve()
        .ByNewContextPrefab<EnemyInstaller>(_assetProvider.Get<Enemy>().GetComponent<EnemyInstaller>())
        .AsSingle();
    }
  }
}