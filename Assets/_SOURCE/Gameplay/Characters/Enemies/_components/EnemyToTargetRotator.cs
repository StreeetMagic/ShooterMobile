using Gameplay.Characters.Enemies;
using UnityEngine;

public class EnemyToTargetRotator
{
  private readonly Enemy _enemy;

  public EnemyToTargetRotator(Enemy enemy)
  {
    _enemy = enemy;
  }

  public void RotateToTargetPosition(Vector3 direction)
  {
    _enemy.transform.rotation = Quaternion.LookRotation(direction);
  }
}