using UnityEngine;

namespace Characters
{
  public interface ITargetTrigger
  {
    void TakeDamage(float damage);
    bool IsTargeted { get; set; }
    IHealth Health { get; }
    float AggroRadius { get; }
    HitStatus HitStatus { get; }
    // ReSharper disable once InconsistentNaming
    Transform transform { get; }
  }
}