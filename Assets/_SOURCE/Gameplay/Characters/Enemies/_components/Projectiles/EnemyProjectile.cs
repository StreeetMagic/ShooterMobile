using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Players;
using Gameplay.Projectiles;
using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigProviders;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.Projectiles
{
  public class EnemyProjectile : MonoBehaviour
  {
    [SerializeField] private LayerMask _layerMask;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private ArtConfigProvider _artConfigs;
    [Inject] private ConfigProvider _configProvider;

    private ProjectileMover _projectileMover;
    private int _count;
    private float _lifeTime;

    public EnemyConfig EnemyConfig { get; set; }

    private void Start()
    {
      _projectileMover = new ProjectileMover();
      _projectileMover.Initialize(EnemyConfig.BulletSpeed);
    }

    private void Update()
    {
      LifeTime();
      
      if (_projectileMover.MoveProjectile(transform, _layerMask, out RaycastHit hit))
        return;

      if (hit.collider.TryGetComponent(out PlayerTargetTrigger player))
      {
        if (_count == 0)
        {
          _count++;
          player.TakeDamage(EnemyConfig.BulletDamage);
        }
      }

      ImpactEffect(hit.point);

      transform.position = hit.point;

      Destroy(gameObject);
    }
    
    private void LifeTime()
    {
      if (_lifeTime >= _configProvider.CommonGameplayConfig.ProjectileLifeTime)
        Destroy(gameObject);
      else
        _lifeTime += Time.deltaTime;
    }

    private void ImpactEffect(Vector3 position)
    {
      VisualEffectId id = _artConfigs.GetEnemyImpactEffectId(EnemyConfig.Id);
      _visualEffectFactory.CreateAndDestroy(id, position, transform.rotation);
    }
  }
}