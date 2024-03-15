using Configs.Resources.EnemyConfigs.Scripts;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Movers
{
  public class EnemyMover : MonoBehaviour
  {
    private EnemyConfig _enemyConfig;
    private CharacterController _characterController;

    private float MoveSpeed => _enemyConfig.MoveSpeed;
    private float RunSpeed => _enemyConfig.RunSpeed;

    public void Init(EnemyConfig enemyConfig)
    {
      _enemyConfig = enemyConfig;

      _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 moveDirection, float deltaTime)
    {
      _characterController.Move(moveDirection * (MoveSpeed * deltaTime));
      
    }
  }
}