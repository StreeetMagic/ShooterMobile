using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.StateMachines.States;
using Gameplay.Characters.Enemies.TargetLocators;
using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
  public Enemy Enemy;
  public CharacterController CharacterController;
  public EnemyAnimator EnemyAnimator;
  public EnemyTargetLocator TargetLocator;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<StateMachine<IEnemyState>>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<RoutePointsManager>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyBootstrapper>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyHealth>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<HealthStatusController>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<Healer>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyComponentsProvider>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle().NonLazy();

    Container.Bind<Enemy>().FromInstance(Enemy).AsSingle().NonLazy();
    Container.Bind<CharacterController>().FromInstance(CharacterController).AsSingle().NonLazy();
    Container.Bind<EnemyAnimator>().FromInstance(EnemyAnimator).AsSingle().NonLazy();
    Container.Bind<EnemyTargetLocator>().FromInstance(TargetLocator).AsSingle().NonLazy(); 
  }
}