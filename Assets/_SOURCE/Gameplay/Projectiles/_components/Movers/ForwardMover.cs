using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles.Movers
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private Rigidbody _rigidbody;

    public float BulletSpeed { get; set; }

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      Vector3 newPosition = transform.position + transform.forward * (BulletSpeed * Time.deltaTime);
      _rigidbody.MovePosition(newPosition);
    }
  }
}