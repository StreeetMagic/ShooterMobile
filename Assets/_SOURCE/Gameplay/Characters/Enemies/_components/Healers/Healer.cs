using System;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class Healer : MonoBehaviour
  {
    private Health _health;
    private HealthStatusController _healthStatusController;

    private float _heal;

    public void Init(Health health, HealthStatusController healthStatusController)
    {
      _health = health;
      _healthStatusController = healthStatusController;
    }

    private void Update()
    {
      if (_health.IsDead)
        return;

      if (_healthStatusController.IsHit)
        return;
      
      if (_health.IsFull)
        return;

      _heal += 0.1f;

      if (_heal >= 1)
      {
        _health.Current.Value++;
        _heal = 0;
      }
    }
  }
}