using Gameplay.Spawners;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyToSpawnerDisance : MonoBehaviour
  {
    [Inject] private EnemyConfig _config;
    [Inject] private EnemySpawner _spawner;

    public float Value => (_spawner.transform.position - transform.position).magnitude;
    public bool IsAway => Value > _config.PatrolingRadius;
  }
}