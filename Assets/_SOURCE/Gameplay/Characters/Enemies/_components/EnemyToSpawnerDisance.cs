using Gameplay.Characters.Enemies;
using UnityEngine;
using Zenject;

public class EnemyToSpawnerDisance : MonoBehaviour
{
  private Enemy _enemy;

  [Inject]
  public void Construct(Enemy enemy)
  {
    _enemy = enemy;
  }

  private Transform SpawnerTransform => _enemy.SpawnerTransform;

  public float Value => (SpawnerTransform.position - transform.position).magnitude;
  public bool IsAway => Value > _enemy.Config.PatrolingRadius;
}