using System;
using Gameplay.Characters.Players.Factories;
using Infrastructure.DataRepositories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyTargetOutline : MonoBehaviour
  {
    public GameObject Outline;

    private EnemyTargetTrigger _enemyTargetTrigger;
    private BackpackStorage _backpackStorage;

    [Inject]
    private void Construct(EnemyTargetTrigger enemyTargetTrigger, BackpackStorage backpackStorage)
    {
      _enemyTargetTrigger = enemyTargetTrigger;
      _backpackStorage = backpackStorage;
    }

    private void Update()
    {
      bool isTargeted = _enemyTargetTrigger.IsTargeted;

      if (_backpackStorage.IsFull)
        isTargeted = false;

      Outline.gameObject.SetActive(isTargeted);
    }
  }
}