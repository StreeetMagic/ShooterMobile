using UnityEngine;

namespace Gameplay.Projectiles.Movers
{
  public class ForwardMover : MonoBehaviour
  {
    public float BulletSpeed { get; set; }

    private void Update()
    {
      transform.position += transform.forward * (BulletSpeed * Time.deltaTime); 
    }
  }
}