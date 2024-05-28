using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyToSpawnerDisance : MonoBehaviour
  {
    [Inject] private EnemyConfig _config;
    [Inject] private Transform _spawnerTransform;

    public float Value => (_spawnerTransform.position - transform.position).magnitude;
    public bool IsAway => Value > _config.PatrolingRadius;
  }
}