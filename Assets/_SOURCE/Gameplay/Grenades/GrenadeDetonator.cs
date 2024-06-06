using System.Collections;
using UnityEngine;
using VisualEffects;
using Zenject;

namespace Gameplay.Grenades
{
  public class GrenadeDetonator : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;

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
      Destroy(gameObject);
    }
  }
}