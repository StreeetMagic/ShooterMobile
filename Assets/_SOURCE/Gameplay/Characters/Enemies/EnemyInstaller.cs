using System.Collections.Generic;
using Gameplay.Characters.Enemies.States;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnPoints;
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
    public EnemyToSpawnerDisance EnemyToSpawnerDisance;
    public EnemyTargetTrigger TargetTrigger;
    public EnemyShootingPoint ShootingPoint;
    public EnemyAnimatorProvider EnemyAnimatorProvider;
    public NavMeshAgent NavMeshAgent;
    public EnemyToPlayerRotator EnemyToPlayerRotator;

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

      Container.Bind<IHealth>().To<EnemyHealth>().FromInstance(EnemyHealth).AsSingle().NonLazy();
      Container.Bind<ITargetTrigger>().To<EnemyTargetTrigger>().FromInstance(TargetTrigger).AsSingle().NonLazy();
      Container.Bind<EnemyHealer>().FromInstance(enemyHealer).AsSingle().NonLazy();
      Container.Bind<EnemyRoutePointsManager>().FromInstance(enemyRoutePointsManager).AsSingle().NonLazy();
      Container.Bind<EnemyAnimatorProvider>().FromInstance(EnemyAnimatorProvider).AsSingle().NonLazy();
      Container.Bind<EnemyToSpawnerDisance>().FromInstance(EnemyToSpawnerDisance).AsSingle().NonLazy();
      Container.Bind<EnemyShootingPoint>().FromInstance(ShootingPoint).AsSingle().NonLazy();
      Container.Bind<NavMeshAgent>().FromInstance(NavMeshAgent).AsSingle().NonLazy();
      Container.Bind<EnemyToPlayerRotator>().FromInstance(EnemyToPlayerRotator).AsSingle().NonLazy();

      Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle().NonLazy();
      Container.Bind<List<SpawnPoint>>().FromInstance(_spawnPoints).AsSingle().NonLazy();
      Container.Bind<Transform>().FromInstance(_spawnPointsContainer).AsSingle().NonLazy();
      Container.Bind<EnemySpawner>().FromInstance(_spawner).AsSingle().NonLazy();
      Container.Bind<EnemyId>().FromInstance(_enemyConfig.Id).AsSingle().NonLazy();

      Container.BindInterfacesAndSelfTo<EnemyStateMachine>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<EnemyStatesProvider>().AsSingle().NonLazy();

      BindStates();
      RegisterStates();
    }

    private void BindStates()
    {
      Container.Bind<EnemyBootstrapState>().AsSingle().NonLazy();
      Container.Bind<EnemyPatrolState>().AsSingle().NonLazy();
      Container.Bind<EnemyRunToPlayerState>().AsSingle().NonLazy();
      Container.Bind<EnemyAttackPlayerState>().AsSingle().NonLazy();
    }

    private void RegisterStates()
    {
      Container.Resolve<EnemyStatesProvider>().AddState(Container.Resolve<EnemyBootstrapState>());
      Container.Resolve<EnemyStatesProvider>().AddState(Container.Resolve<EnemyPatrolState>());
      Container.Resolve<EnemyStatesProvider>().AddState(Container.Resolve<EnemyRunToPlayerState>());
      Container.Resolve<EnemyStatesProvider>().AddState(Container.Resolve<EnemyAttackPlayerState>());
    }
  }
}