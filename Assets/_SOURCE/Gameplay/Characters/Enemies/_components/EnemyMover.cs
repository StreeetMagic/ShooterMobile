using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover
  {
    private readonly CharacterController _characterController;
    private readonly Enemy _enemy;

    private EnemyMover(CharacterController characterController, Enemy enemy)
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