using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.TargetTriggers;
using UnityEngine;

namespace Gameplay.Dummies
{
  public class DummyTargetTrigger : MonoBehaviour, ITargetTrigger
  {
    [SerializeField] private DummyHealth _dummyHealth;

    public IHealth Health => _dummyHealth;
    public bool IsTargeted { get; set; }

    public void TakeDamage(float damage)
    {
      _dummyHealth.TakeDamage(damage);
    }
  }
}