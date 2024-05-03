using Configs.Resources.VisualEffectConfigs;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens._components
{
  public class HenVisualEffector : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;

    public void PlayExplosion()
    {
      _visualEffectFactory.Create(ParticleEffectId.HenExplosion, transform.position, null);
    }
  }
}