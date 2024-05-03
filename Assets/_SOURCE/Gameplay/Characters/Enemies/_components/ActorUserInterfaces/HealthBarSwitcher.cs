using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces
{
  public class HealthBarSwitcher : MonoBehaviour
  {
    public GameObject[] Components;

    [Inject] private EnemyHealth _enemyHealth;

    public void Start()
    {
      _enemyHealth.Current.ValueChanged += OnHealthChanged;
      OnHealthChanged(0);
    }

    public void OnDestroy()
    {
      _enemyHealth.Current.ValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int _)
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