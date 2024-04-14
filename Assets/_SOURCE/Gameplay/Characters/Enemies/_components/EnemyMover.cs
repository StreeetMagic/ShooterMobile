using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover
  {
    private readonly CharacterController _characterController;
    private readonly Enemy _enemy;
    private readonly EnemyToTargetRotator _enemyToTargetRotator;

    private EnemyMover(CharacterController characterController, Enemy enemy, EnemyToTargetRotator enemyToTargetRotator)
    {
      _characterController = characterController;
      _enemy = enemy;
      _enemyToTargetRotator = enemyToTargetRotator;
    }

    public void Move(Vector3 moveDirection, float moveSpeed)
    {
      _characterController.Move(moveDirection * (moveSpeed * Time.fixedDeltaTime));
      _enemyToTargetRotator.RotateToTargetPosition(moveDirection);
    }
  }
}