using System.Collections.Generic;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Enemies.TargetTriggers;
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
    public EnemyRoutePointsManager enemyRoutePointsManager;
    public EnemyHealer enemyHealer;
    public EnemyMoverToSpawnPoint EnemyMoverToSpawnPoint;
    public EnemyWaiter EnemyWaiter;
    public EnemyMoverToPlayer EnemyMoverToPlayer;
    public EnemyShootAtPlayer EnemyShooter;
    public EnemyToSpawnerDisance EnemyToSpawnerDisance;
    public EnemyTargetTrigger TargetTrigger;
    public EnemyShootingPoint ShootingPoint;
    public EnemyAnimatorProvider EnemyAnimatorProvider;
    public EnemyGrenadeThrower EnemyGrenadeThrower;
    public NavMeshAgent NavMeshAgent;

    [Inject] private EnemyConfig _enemyConfig;
    [Inject] private List<SpawnPoint> _spawnPoints;
    [Inject] private Transform _spawnPointsContainer;
    [Inject] private EnemySpawner _spawner;

    public override void InstallBindings()
    {
      Container.Bind<Enemy>().FromInstance(Enemy).AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyReturnToSpawnStatus>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<HitStatus>().AsSingle().NonLazy();
      
      Container.BindInterfacesAndSelfTo<EnemyStateMachine>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyBootstrapState>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyPatrolState>().AsSingle().NonLazy();

      Container.Bind<EnemyHealer>().FromInstance(enemyHealer).AsSingle().NonLazy();
      Container.Bind<EnemyRoutePointsManager>().FromInstance(enemyRoutePointsManager).AsSingle().NonLazy();
      Container.Bind<IHealth>().To<EnemyHealth>().FromInstance(EnemyHealth).AsSingle().NonLazy();
      Container.Bind<EnemyAnimatorProvider>().FromInstance(EnemyAnimatorProvider).AsSingle().NonLazy();
      Container.Bind<EnemyMoverToSpawnPoint>().FromInstance(EnemyMoverToSpawnPoint).AsSingle().NonLazy();
      Container.Bind<EnemyWaiter>().FromInstance(EnemyWaiter).AsSingle().NonLazy();
      Container.Bind<EnemyMoverToPlayer>().FromInstance(EnemyMoverToPlayer).AsSingle().NonLazy();
      Container.Bind<EnemyShootAtPlayer>().FromInstance(EnemyShooter).AsSingle().NonLazy();
      Container.Bind<EnemyToSpawnerDisance>().FromInstance(EnemyToSpawnerDisance).AsSingle().NonLazy();
      Container.Bind<ITargetTrigger>().To<EnemyTargetTrigger>().FromInstance(TargetTrigger).AsSingle().NonLazy();
      Container.Bind<EnemyShootingPoint>().FromInstance(ShootingPoint).AsSingle().NonLazy();
      Container.Bind<EnemyGrenadeThrower>().FromInstance(EnemyGrenadeThrower).AsSingle().NonLazy();
      Container.Bind<NavMeshAgent>().FromInstance(NavMeshAgent).AsSingle().NonLazy();

      Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle().NonLazy();
      Container.Bind<List<SpawnPoint>>().FromInstance(_spawnPoints).AsSingle().NonLazy();
      Container.Bind<Transform>().FromInstance(_spawnPointsContainer).AsSingle().NonLazy();
      Container.Bind<EnemySpawner>().FromInstance(_spawner).AsSingle().NonLazy();
      Container.Bind<EnemyId>().FromInstance(_enemyConfig.Id).AsSingle().NonLazy();
    }
  }
}