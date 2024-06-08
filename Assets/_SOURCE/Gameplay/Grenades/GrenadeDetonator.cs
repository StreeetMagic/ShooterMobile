using System.Collections;
using Gameplay.Characters.Players;
using UnityEngine;
using VisualEffects;
using Zenject;

namespace Gameplay.Grenades
{
  public class GrenadeDetonator : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;

    private GrenadeConfig _config;

    private float _timeLeft;

    public void Init(GrenadeConfig config)
    {
      _config = config;

      _timeLeft = _config.DetonationTime;
    }

    public void Detonate()
    {
      StartCoroutine(DetonateGrenade());
    }

    private IEnumerator DetonateGrenade()
    {
      while (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        yield return null;
      }

      _visualEffectFactory.Create(ParticleEffectId.HenExplosion, transform.position, null);

      DamagePlayer();

      Destroy(gameObject);
    }

    private void DamagePlayer()
    {
      PlayerHealth playerHealth = _playerProvider.Instance.Health;

      if (playerHealth == null)
        return;
      
      float distance = Vector3.Distance(_playerProvider.Instance.Transform.position, transform.position);
      
      if (distance > _config.DetonationRadius)
        return;

      playerHealth.TakeDamage(_config.Damage);
    }
  }
}