using UnityEngine;

namespace Gameplay.Characters.Players.Shooters.Projectiles
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private Rigidbody _rigidbody;

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      _rigidbody.velocity = transform.forward * 20f;
    }
  }
}