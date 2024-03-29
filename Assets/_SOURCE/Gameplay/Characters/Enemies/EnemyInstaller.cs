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
  public Transform Transform;
  public EnemyAnimator EnemyAnimator;
  public EnemyTargetLocator TargetLocator;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<StateMachine<IEnemyState>>().AsSingle();
    Container.Bind<EnemyMover>().AsSingle();
    Container.Bind<RoutePointsManager>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemyBootstrapper>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemyHealth>().AsSingle();
    Container.BindInterfacesAndSelfTo<HealthStatusController>().AsSingle().NonLazy();
    Container.BindInterfacesAndSelfTo<Healer>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemyComponentsProvider>().AsSingle();
    Container.BindInterfacesAndSelfTo<EnemyShooter>().AsSingle();

    Container.BindInstance(Enemy);
    Container.BindInstance(CharacterController);
    Container.BindInstance(Transform);
    Container.BindInstance(EnemyAnimator);
    Container.BindInstance(TargetLocator);
  }
}