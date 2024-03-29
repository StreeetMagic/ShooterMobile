using Configs.Resources.EnemyConfigs.Scripts;
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

    public void Move(Vector3 moveDirection, float deltaTime, float moveSpeed)
    {
      _characterController.Move(moveDirection * (moveSpeed * deltaTime));
      RotateToTargetPosition(moveDirection);
    }

    public void Disable()
    {
      _characterController.enabled = false;
    }

    private void RotateToTargetPosition(Vector3 moveDirection)
    {
      _enemy.transform.rotation = Quaternion.LookRotation(moveDirection);
    }
  }
}