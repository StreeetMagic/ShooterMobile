using Configs.Resources.VisualEffectConfigs;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens._components
{
  public class HenVisualEffector : MonoBehaviour
  {
    public float CoolDown = 1f;

    private float _timeLeft
      ;

    [Inject] private VisualEffectFactory _visualEffectFactory;

    public void Update()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
      }
      else
      {
        _timeLeft = CoolDown;
        _visualEffectFactory.Create(ParticleEffectId.HenExplosion, transform.position, null);
      }
    }
  }
}