using Configs.Resources.EnemyConfigs.Scripts;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover
  {
    private readonly CharacterController _characterController;
    private readonly Transform _transform;

    private EnemyMover(CharacterController characterController, Transform transform)
    {
      _characterController = characterController;
      _transform = transform;
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
      _transform.rotation = Quaternion.LookRotation(moveDirection);
    }
  }
}