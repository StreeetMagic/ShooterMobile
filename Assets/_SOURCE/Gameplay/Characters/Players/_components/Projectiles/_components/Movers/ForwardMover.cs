using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles.Movers
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private IStaticDataService _staticDataService;
    private Rigidbody _rigidbody;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _rigidbody = GetComponent<Rigidbody>();
    }

    private float BulletSpeed => _staticDataService.GetPlayerConfig().BulletSpeed;

    private void FixedUpdate()
    {
      Vector3 newPosition = transform.position + transform.forward * (BulletSpeed * Time.deltaTime);
      _rigidbody.MovePosition(newPosition);
    }
  }
}