using Gameplay.Characters.Enemies.StateMachines.States;
using Infrastructure.StateMachines;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyDebugger : MonoBehaviour
  {
    private StateMachine<IEnemyState> _stateMachine;

    [Inject]
    public void Construct(StateMachine<IEnemyState> stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    private void Update()
    {
      var s = _stateMachine.ActiveState.ToString();
      
      //Debug.Log(s);
    }
  }
}