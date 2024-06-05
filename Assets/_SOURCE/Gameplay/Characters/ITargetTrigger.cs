using Gameplay.Characters.Enemies.Healths;
using UnityEngine;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public interface ITargetTrigger
  {
    void TakeDamage(float damage);
    bool IsTargeted { get; set; }
    IHealth Health { get; }
    Transform transform { get; }
  }
}