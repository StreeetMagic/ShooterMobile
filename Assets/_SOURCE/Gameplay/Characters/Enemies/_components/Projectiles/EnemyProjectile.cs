using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Players;
using Infrastructure.ArtConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    [SerializeField] private LayerMask _layerMask;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private ArtConfigProvider _configProvider;

    private ProjectileMover _projectileMover;
    private int _count;

    public EnemyConfig EnemyConfig { get; set; }

    private void Start()
    {
      _projectileMover = new ProjectileMover();
      _projectileMover.Initialize(EnemyConfig.BulletSpeed);
      Destroy(gameObject, 2f);
    }

    private void Update()
    {
      if (_projectileMover.MoveProjectile(transform, _layerMask, out RaycastHit hit))
      {
        if (hit.collider.TryGetComponent(out PlayerTargetTrigger player))
        {
          if (_count == 0)
          {
            _count++;
            player.TakeDamage(EnemyConfig.BulletDamage);
          }
        }

        DestroyProjectile(hit.point);
      }
    }

    private void ImpactEffect(Vector3 position)
    {
      VisualEffectId id = _configProvider.GetEnemyImpactEffectId(EnemyConfig.Id);
      _visualEffectFactory.CreateAndDestroy(id, position, transform.rotation);
    }

    private void DestroyProjectile(Vector3 position, float time = default)
    {
      transform.position = position;
      ImpactEffect(position);
      Destroy(gameObject, time);
    }
  }
}