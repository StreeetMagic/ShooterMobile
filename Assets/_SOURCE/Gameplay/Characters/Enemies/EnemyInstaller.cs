using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.TargetLocators;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
  public Enemy Enemy;
  public CharacterController CharacterController;
  public EnemyAnimator EnemyAnimator;
  public EnemyTargetLocator TargetLocator;
  public EnemyHealth EnemyHealth;
  public EnemyMover EnemyMover;
  public RoutePointsManager RoutePointsManager;
  public HealthStatusController HealthStatusController;
  public EnemyHealer enemyHealer;
  public EnemyMoverToSpawnPoint EnemyMoverToSpawnPoint;
  public EnemyWaiter EnemyWaiter;
  public EnemyMoverToPlayer EnemyMoverToPlayer;
  public EnemyShootAtPlayer EnemyShooter;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle().NonLazy();

    Container.Bind<EnemyHealer>().FromInstance(enemyHealer).AsSingle().NonLazy();
    Container.Bind<HealthStatusController>().FromInstance(HealthStatusController).AsSingle().NonLazy();
    Container.Bind<RoutePointsManager>().FromInstance(RoutePointsManager).AsSingle().NonLazy();
    Container.Bind<EnemyMover>().FromInstance(EnemyMover).AsSingle().NonLazy();
    Container.Bind<EnemyHealth>().FromInstance(EnemyHealth).AsSingle().NonLazy();
    Container.Bind<Enemy>().FromInstance(Enemy).AsSingle().NonLazy();
    Container.Bind<CharacterController>().FromInstance(CharacterController).AsSingle().NonLazy();
    Container.Bind<EnemyAnimator>().FromInstance(EnemyAnimator).AsSingle().NonLazy();
    Container.Bind<EnemyTargetLocator>().FromInstance(TargetLocator).AsSingle().NonLazy(); 
    Container.Bind<EnemyMoverToSpawnPoint>().FromInstance(EnemyMoverToSpawnPoint).AsSingle().NonLazy();
    Container.Bind<EnemyWaiter>().FromInstance(EnemyWaiter).AsSingle().NonLazy();
    Container.Bind<EnemyMoverToPlayer>().FromInstance(EnemyMoverToPlayer).AsSingle().NonLazy();
    Container.Bind<EnemyShootAtPlayer>().FromInstance(EnemyShooter).AsSingle().NonLazy();
  }
}