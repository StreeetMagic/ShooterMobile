using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyTargetOutline : MonoBehaviour
  {
    public GameObject Outline;

    private EnemyTargetTrigger _enemyTargetTrigger;

    [Inject]
    private void Construct(EnemyTargetTrigger enemyTargetTrigger)
    {
      _enemyTargetTrigger = enemyTargetTrigger;
    }

    private void Update()
    {
      bool isTargeted = _enemyTargetTrigger.IsTargeted;
      
      Outline.gameObject.SetActive(isTargeted);
    }
  }
}