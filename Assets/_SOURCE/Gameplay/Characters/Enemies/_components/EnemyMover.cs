using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover : MonoBehaviour
  {
    private CharacterController _characterController;
    private Enemy _enemy;

    [Inject]
    private void Construct(CharacterController characterController, Enemy enemy)
    {
      _characterController = characterController;
      _enemy = enemy;
    }

    public void Move(Vector3 moveDirection, float moveSpeed)
    {
      _characterController.Move(moveDirection * (moveSpeed * Time.fixedDeltaTime));
      RotateToTargetPosition(moveDirection);
    }

    private void RotateToTargetPosition(Vector3 moveDirection)
    {
      _enemy.transform.rotation = Quaternion.LookRotation(moveDirection);
    }
  }
}