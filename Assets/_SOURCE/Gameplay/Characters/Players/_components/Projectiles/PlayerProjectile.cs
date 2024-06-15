using Gameplay.Projectiles.Raycasters;
using Infrastructure.ConfigServices;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Projectiles
{
  public class PlayerProjectile : MonoBehaviour
  {
    public CollisionPointRayCaster CollisionPointRayCaster;

    private int _count;

    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ConfigService _configService;

    public string Guid { get; set; }

    private void OnTriggerEnter(Collider otherCollider)
    {
      DamageTargetTrigger(otherCollider);
    }

    private void PlayerVisualEffect()
    {
      _visualEffectFactory.Create(VisualEffectId.PlayerBulletImpact, transform.position, transform);
    }

    private void DamageTargetTrigger(Collider other)
    {
      if (other.gameObject.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
      {
        if (_count == 0)
        {
          _count++;
          enemyTargetTrigger.TakeDamage(_configService.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Damage);
        }
      }

      Destroy();
    }

    private void Destroy()
    {
     // transform.position = CollisionPointRayCaster.HitPosition;
     
      PlayerVisualEffect();
      Destroy(gameObject);
    }
  }
}