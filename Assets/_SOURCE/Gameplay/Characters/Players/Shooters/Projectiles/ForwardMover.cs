using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters.Projectiles
{
  [RequireComponent(typeof(Rigidbody))]
  public class ForwardMover : MonoBehaviour
  {
    private IStaticDataService _staticDataService;
    private Rigidbody _rigidbody;

    private float BulletSpeed => _staticDataService.ForPlayer().BulletSpeed;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    private void Awake()
    {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      _rigidbody.velocity = transform.forward * BulletSpeed;
    }
  }
}