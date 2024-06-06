using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyToPlayerRotator : MonoBehaviour
  {
    [Inject] private Enemy _enemy;

    public void RotateToTargetPosition(Vector3 target)
    {
      Vector3 direction = target - _enemy.transform.position;

      _enemy.transform.rotation = Quaternion.LookRotation(direction);
    }
  }
}