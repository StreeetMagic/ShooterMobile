using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles.Movers
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private Rigidbody _rigidbody;

    [Inject] private IStaticDataService _staticDataService;

    private float BulletSpeed => _staticDataService.GetPlayerConfig().BulletSpeed;

    private void Start()
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