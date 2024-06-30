using System.Collections;
using Characters.Players;
using Characters.Players._components;
using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Grenades
{
  public class GrenadeDetonator : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;
    [Inject] private PlayerProvider _playerProvider;

    private GrenadeConfig _config;

    private float _timeLeft;
    private float _scale;

    public void Init(GrenadeConfig grenadeConfig, float scale)
    {
      _config = grenadeConfig;
      _timeLeft = _config.DetonationTime;
      _scale = scale;
      
      if (scale == 0)
        throw new System.Exception("Scale can't be zero");
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

      _visualEffectFactory.CreateAndDestroy(VisualEffectId.GrenadeExplosion, transform.position, Quaternion.identity, _scale);

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