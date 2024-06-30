using System;
using Characters.Enemies.Configs;
using UnityEngine;
using Zenject;

namespace Characters.Enemies._components.TargetTriggers
{
  public class EnemyTargetTrigger : MonoBehaviour, ITargetTrigger
  {
    public Collider Collider;
    
    [Inject] private EnemyConfig _config;

    public event Action<ITargetTrigger> TargetDied;

    [Inject] public IHealth Health { get; private set; }
    [Inject] public HitStatus HitStatus { get; private set; }
    
    public bool IsTargeted { get; set; }
    public float AggroRadius => _config.AggroRadius;

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

    public void TakeDamage(float damage)
    {
      Health.TakeDamage(damage);
    }
  }
}