using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
  public Enemy Enemy;
  public CharacterController CharacterController;
  public EnemyAnimator EnemyAnimator;
  public EnemyHealth EnemyHealth;
  public RoutePointsManager RoutePointsManager;
  public EnemyHealer enemyHealer;
  public EnemyMoverToSpawnPoint EnemyMoverToSpawnPoint;
  public EnemyWaiter EnemyWaiter;
  public EnemyMoverToPlayer EnemyMoverToPlayer;
  public EnemyShootAtPlayer EnemyShooter;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<ReturnToSpawnStatus>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<HitStatus>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyToTargetRotator>().AsSingle().NonLazy();

    Container.Bind<EnemyHealer>().FromInstance(enemyHealer).AsSingle().NonLazy();
    Container.Bind<RoutePointsManager>().FromInstance(RoutePointsManager).AsSingle().NonLazy();
    Container.Bind<EnemyHealth>().FromInstance(EnemyHealth).AsSingle().NonLazy();
    Container.Bind<Enemy>().FromInstance(Enemy).AsSingle().NonLazy();
    Container.Bind<CharacterController>().FromInstance(CharacterController).AsSingle().NonLazy();
    Container.Bind<EnemyAnimator>().FromInstance(EnemyAnimator).AsSingle().NonLazy();
    Container.Bind<EnemyMoverToSpawnPoint>().FromInstance(EnemyMoverToSpawnPoint).AsSingle().NonLazy();
    Container.Bind<EnemyWaiter>().FromInstance(EnemyWaiter).AsSingle().NonLazy();
    Container.Bind<EnemyMoverToPlayer>().FromInstance(EnemyMoverToPlayer).AsSingle().NonLazy();
    Container.Bind<EnemyShootAtPlayer>().FromInstance(EnemyShooter).AsSingle().NonLazy();
  }
}