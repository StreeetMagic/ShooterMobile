using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters.Players.Shooters.Projectiles;
using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
  public Health Health;

  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent(out Projectile projectile))
    {
      Health.TakeDamage(projectile.Damage);

      Destroy(projectile.gameObject);
    }
  }
}