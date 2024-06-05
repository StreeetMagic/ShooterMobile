using System;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyTargetTrigger : MonoBehaviour, ITargetTrigger
  {
    public Collider Collider;

    public event Action<ITargetTrigger> TargetDied;

    public bool IsTargeted { get; set; }
    [Inject] public IHealth Health { get; private set; }

    private void OnEnable()
    {
      Health.Died += OnDied;
    }

    private void OnDisable()
    {
      Health.Died -= OnDied; 
    }

    private void OnDied(EnemyConfig arg1, IHealth arg2)
    {
      Collider.enabled = false;

      TargetDied?.Invoke(this);
    }

    private void FixedUpdate()
    {
      transform.localPosition = Vector3.zero;
    }

    public void TakeDamage(float damage)
    {
      Health.TakeDamage(damage);
    }
  }
}