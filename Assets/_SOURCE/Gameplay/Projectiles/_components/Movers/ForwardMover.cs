using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles.Movers
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private Rigidbody _rigidbody;

    [Inject] private ConfigService _configService;

    private float BulletSpeed => _configService.PlayerConfig.BulletSpeed;

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