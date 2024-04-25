using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMover
  {
    private readonly CharacterController _characterController;
    private readonly EnemyToTargetRotator _enemyToTargetRotator;

    private EnemyMover(CharacterController characterController, EnemyToTargetRotator enemyToTargetRotator)
    {
      _characterController = characterController;
      _enemyToTargetRotator = enemyToTargetRotator;
    }

    public void Move(Vector3 moveDirection, float moveSpeed)
    {
      _characterController.Move(moveDirection * (moveSpeed * Time.fixedDeltaTime));
      _enemyToTargetRotator.RotateToTargetPosition(moveDirection);
    }
  }
}