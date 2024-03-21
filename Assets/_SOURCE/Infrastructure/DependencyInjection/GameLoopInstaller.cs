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
using UnityEngine;
using UnityEngine.SceneManagement;
using UserInterface.HeadsUpDisplays;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;
using Zenject;

public class GameLoopInstaller : MonoInstaller
{
  public override void InstallBindings()
  {

    
    Container.Bind<MapFactory>().AsSingle();
    Container.Bind<PlayerFactory>().AsSingle().NonLazy();
    Container.Bind<CameraFactory>().AsSingle();
    Container.Bind<EnemySpawnerFactory>().AsSingle();
    Container.Bind<HeadsUpDisplayFactory>().AsSingle();
    Container.Bind<BaseTriggerFactory>().AsSingle();
    Container.Bind<UpgradeCellFactory>().AsSingle();

    Container.Bind<EnemyFactory>().AsSingle();

  }
}