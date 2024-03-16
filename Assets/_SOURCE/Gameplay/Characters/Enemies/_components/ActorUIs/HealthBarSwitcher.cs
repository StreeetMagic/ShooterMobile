using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;

public class HealthBarSwitcher : MonoBehaviour
{
  public GameObject[] Components;

  private Health _health;

  public void Init(Health health)
  {
    _health = health;

    _health.Current.ValueChanged += OnHealthChanged;

    OnHealthChanged(0);
  }

  private void OnHealthChanged(int _)
  {
    if (_health.IsFull)
    {
      foreach (var component in Components)
      {
        component.SetActive(false);
      }
    }
    else
    {
      foreach (var component in Components)
      {
        component.SetActive(true);
      }
    }
  }
}