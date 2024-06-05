using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class HealthBarSwitcher : MonoBehaviour
  {
    public GameObject[] Components;

    [Inject] private IHealth _enemyHealth;

    public void Start()
    {
      _enemyHealth.Current.ValueChanged += OnHealthChanged;
      OnHealthChanged(0);
    }

    public void OnDestroy()
    {
      _enemyHealth.Current.ValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float _)
    {
      if (_enemyHealth.IsFull)
        foreach (GameObject component in Components)
          component.SetActive(false);
      else
        foreach (GameObject component in Components)
          component.SetActive(true);
    }
  }
}