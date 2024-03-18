using Configs.Resources.EnemyConfigs.Scripts;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover : MonoBehaviour
  {
    private CharacterController _characterController;

    public void Init(EnemyConfig enemyConfig)
    {
      _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 moveDirection, float deltaTime, float moveSpeed)
    {
      _characterController.Move(moveDirection * (moveSpeed * deltaTime));
      RotateToTargetPosition(moveDirection);
    }

    public void Disable()
    {
      enabled = false;
      _characterController.enabled = false;
    }

    private void RotateToTargetPosition(Vector3 moveDirection)
    {
      transform.rotation = Quaternion.LookRotation(moveDirection);
    }
  }
}