using Gameplay.Characters.Enemies.TargetTriggers;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyAssistCall
  {
    public const float CallRadius = 50;

    private readonly Transform _transform;
    private readonly Collider[] _enemies = new Collider[50];

    public EnemyAssistCall(Transform transform)
    {
      _transform = transform;
    }

    public void Call()
    {
      int count = Physics.OverlapSphereNonAlloc(_transform.position, CallRadius, _enemies);

      for (int i = 0; i < count; i++)
      {
        if (_enemies[i].TryGetComponent(out EnemyTargetTrigger enemyTargetTrigger))
        {
          enemyTargetTrigger.transform.parent.GetComponent<Enemy>().Health.Hit();
          Debug.Log("Вызвал хит");
        }
      }
    }
  }
}