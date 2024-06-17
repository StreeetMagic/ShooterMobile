using UnityEngine;

namespace Gameplay.Characters.Dummies
{
  public class DummyTargetTrigger : MonoBehaviour, ITargetTrigger
  {
    [SerializeField] private DummyHealth _dummyHealth;

    public IHealth Health => _dummyHealth;
    public float AggroRadius { get; } = 1f;
    public HitStatus HitStatus { get; } = new(null);

    public bool IsTargeted { get; set; }

    public void TakeDamage(float damage)
    {
      _dummyHealth.TakeDamage(damage);
    }
  }
}