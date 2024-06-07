using UnityEngine;

namespace Gameplay.Characters.Pets.Hens._components
{
  public class HenRotator : MonoBehaviour
  {
    public void Rotate(Vector3 target)
    {
      Vector3 direction = (target - transform.position).normalized;
      transform.rotation = Quaternion.LookRotation(direction);
    }
  }
}