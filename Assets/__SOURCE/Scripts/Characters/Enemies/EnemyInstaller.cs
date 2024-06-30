using System.Collections.Generic;
using Characters.Enemies._components;
using Characters.Enemies._components.StateMachines;
using Characters.Enemies._components.TargetTriggers;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Infrastructure.ZenjectFactories.GameobjectContext;
using Spawners;
using Spawners.SpawnPoints;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Zenject.Source.Install;

namespace Characters.Enemies
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
      Container.Bind<Enemy>().FromInstance(Enemy).AsSingle();
      Container.Bind<Transform>().FromInstance(transform).AsSingle();

      Container.Bind<IGameObjectZenjectFactory>().To<EnemyZenjectFactory>().AsSingle();

      Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();
      Container.Bind<List<SpawnPoint>>().FromInstance(_spawnPoints).AsSingle();
      Container.Bind<EnemySpawner>().FromInstance(_spawner).AsSingle();
      Container.Bind<EnemyTypeId>().FromInstance(_enemyConfig.Id).AsSingle();
      
      Container.Bind<IStateMachineFactory>().To<EnemyStateMachineFactory>().AsSingle();

      Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyReturnToSpawnStatus>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle();
      Container.BindInterfacesAndSelfTo<HitStatus>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyMeleeAttacker>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyAnimatorProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyToPlayerRotator>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyShootingPointProvider>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyMeshModelSpawner>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyToSpawnerDistance>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyGrenadeThrower>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyColliderDisabler>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyHealer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyRoutePointsManager>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyAssistCall>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyMeshMaterialChanger>().AsSingle();
      Container.BindInterfacesAndSelfTo<FiniteStateMachine>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyIdleTimer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyAlertTimer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyGrenadeStorage>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyGrenadeThrowTimer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyWeaponRaiser>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyWeaponLowerer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyWeaponMagazine>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyWeaponMagazineReloaderTimer>().AsSingle();
      Container.BindInterfacesAndSelfTo<EnemyExpirience>().AsSingle();

      Container.Bind<IHealth>().To<EnemyHealth>().FromInstance(EnemyHealth).AsSingle();
      Container.Bind<ITargetTrigger>().To<EnemyTargetTrigger>().FromInstance(TargetTrigger).AsSingle();
      Container.Bind<NavMeshAgent>().FromInstance(NavMeshAgent).AsSingle();
    }
  }
}