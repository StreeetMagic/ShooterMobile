using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles.Movers
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private Rigidbody _rigidbody;

    [Inject] private ConfigProvider _configProvider;

    private float BulletSpeed => _configProvider.PlayerConfig.BulletSpeed;

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