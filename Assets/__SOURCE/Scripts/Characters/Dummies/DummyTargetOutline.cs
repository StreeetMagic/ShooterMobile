using CurrencyRepositories.BackpackStorages;
using UnityEngine;
using Zenject;

namespace Characters.Dummies
{
  public class DummyTargetOutline : MonoBehaviour
  {
    public GameObject Outline;

    [SerializeField] private DummyTargetTrigger _targetTrigger;
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