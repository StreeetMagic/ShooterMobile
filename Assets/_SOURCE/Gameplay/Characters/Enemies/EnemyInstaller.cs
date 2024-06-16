using System.Collections.Generic;
using Gameplay.Characters.Enemies.StateMachines;
using Gameplay.Characters.Enemies.StateMachines.States.Switchers;
using Gameplay.Characters.Enemies.StateMachines.States.Tickables;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnPoints;
using Infrastructure.ZenjectFactories.GameobjectContext;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Zenject.Source.Install;

namespace Gameplay.Characters.Enemies
{
  public class EnemyInstaller : MonoInstaller
  {
    public Enemy Enemy;
    public EnemyHealth EnemyHealth;
    public EnemyTargetTrigger TargetTrigger;
    public NavMeshAgent NavMeshAgent;

    [Inject] private EnemyConfig _enemyConfig;
    [Inject] private List<SpawnPoint> _spawnPoints;
    [Inject] private EnemySpawner _spawner;

    public override void InstallBindings()
    {
      Container.Bind<Enemy>().FromInstance(Enemy).AsSingle().NonLazy();
      Container.Bind<Transform>().FromInstance(transform).AsSingle().NonLazy();

      Container.Bind<EnemyZenjectFactory>().AsSingle().NonLazy();

      Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle().NonLazy();
      Container.Bind<List<SpawnPoint>>().FromInstance(_spawnPoints).AsSingle().NonLazy();
      Container.Bind<EnemySpawner>().FromInstance(_spawner).AsSingle().NonLazy();
      Container.Bind<EnemyTypeId>().FromInstance(_enemyConfig.Id).AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<EnemyStateMachine>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyStatesProvider>().AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyReturnToSpawnStatus>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<HitStatus>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyWeaponReloader>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMeleeAttacker>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyAnimatorProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyToPlayerRotator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyShootingPointProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMeshModelSpawner>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyToSpawnerDistance>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyGrenadeThrower>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyColliderDisabler>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyHealer>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyRoutePointsManager>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMaxAttakingRange>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyAssistCall>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMeshMaterialChanger>().AsSingle().NonLazy();

      Container.Bind<IHealth>().To<EnemyHealth>().FromInstance(EnemyHealth).AsSingle().NonLazy();
      Container.Bind<ITargetTrigger>().To<EnemyTargetTrigger>().FromInstance(TargetTrigger).AsSingle().NonLazy();
      Container.Bind<NavMeshAgent>().FromInstance(NavMeshAgent).AsSingle().NonLazy();

      BindStates();
      RegisterStates();
    }

    private void BindStates()
    {
      Container.Bind<EnemyBootstrapState>().AsSingle().NonLazy();
      Container.Bind<EnemyPatrolingState>().AsSingle().NonLazy();
      Container.Bind<EnemyChasingPlayerState>().AsSingle().NonLazy();
      Container.Bind<EnemyChooseAttackState>().AsSingle().NonLazy();
      Container.Bind<EnemyChooseCondiditionState>().AsSingle().NonLazy();
      Container.Bind<EnemyThrowingGrenadeState>().AsSingle().NonLazy();
      Container.Bind<EnemyShootingState>().AsSingle().NonLazy();
      Container.Bind<EnemyMeleeAttackingState>().AsSingle().NonLazy();
      Container.Bind<EnemyReloadingWeaponState>().AsSingle().NonLazy();
      Container.Bind<EnemyDyingState>().AsSingle().NonLazy();
    }

    private void RegisterStates()
    {
      var enemyStatesProvider = Container.Resolve<EnemyStatesProvider>();
      
      enemyStatesProvider.AddState(Container.Resolve<EnemyBootstrapState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyPatrolingState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyChasingPlayerState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyChooseAttackState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyChooseCondiditionState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyThrowingGrenadeState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyShootingState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyMeleeAttackingState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyReloadingWeaponState>());
      enemyStatesProvider.AddState(Container.Resolve<EnemyDyingState>());
    }
  }
}