using System;
using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class Enemy : MonoBehaviour
  {
    private StateMachine<IEnemyState> _stateMachine;

    [Inject]
    public void Construct(EnemyComponentsProvider componentsProvider, StateMachine<IEnemyState> stateMachine)
    {
      ComponentsProvider = componentsProvider;
      _stateMachine = stateMachine;
    }

    public EnemyComponentsProvider ComponentsProvider { get; set; }
    public int Id { get; set; } = -1;

    [Button]
    private void Kill()
    {
      ComponentsProvider.Destroyed?.Invoke();
    }

    private void Update()
    {
     // Debug.Log(_stateMachine.ActiveState.ToString());
    }
  }
}