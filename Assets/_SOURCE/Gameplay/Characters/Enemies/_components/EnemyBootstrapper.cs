using Gameplay.Characters.Enemies.StateMachines;
using Gameplay.Characters.Enemies.StateMachines.States;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyBootstrapper : MonoBehaviour
  {
    [Inject] private EnemyStateMachine _enemyStateMachine;

    private void Start()
    {
      _enemyStateMachine.Enter<EnemyBootstrapState>();
    }
  }
}