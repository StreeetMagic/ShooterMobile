using CurrencyRepositories.BackpackStorages;
using UnityEngine;
using Zenject;

namespace Characters.Enemies._components.TargetTriggers
{
  public class EnemyTargetOutline : MonoBehaviour
  {
    public GameObject Outline;

    [Inject] private ITargetTrigger _targetTrigger;
    [Inject] private BackpackStorage _backpackStorage;

    private void Update()
    {
      bool isTargeted = _targetTrigger.IsTargeted;

      if (_backpackStorage.IsFull)
        isTargeted = false;

      Outline.gameObject.SetActive(isTargeted);
    }
  }
}