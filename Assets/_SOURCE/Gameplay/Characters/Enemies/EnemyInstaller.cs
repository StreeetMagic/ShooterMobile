using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
  public Enemy Enemy;
  public CharacterController CharacterController;
  public Transform Transform;
  public EnemyMover EnemyMover;
  public EnemyHealth enemyHealth;
  public HealthStatusController HealthStatusController;
  public EnemyAnimator EnemyAnimator;

  public override void InstallBindings()
  {
    Container.Bind<StateMachine<IEnemyState>>().AsSingle();

    Container.BindInstance(Enemy);
    Container.BindInstance(CharacterController);
    Container.BindInstance(Transform);
    Container.BindInstance(EnemyMover);
    Container.BindInstance(enemyHealth);
    Container.BindInstance(HealthStatusController);
    Container.BindInstance(EnemyAnimator);
  }
}