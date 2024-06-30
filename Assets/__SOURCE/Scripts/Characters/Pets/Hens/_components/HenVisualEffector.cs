using Infrastructure.VisualEffects;
using UnityEngine;
using Zenject;

namespace Characters.Pets.Hens._components
{
  public class HenVisualEffector : MonoBehaviour
  {
    [Inject] private VisualEffectFactory _visualEffectFactory;

    public void PlayExplosion()
    {
      _visualEffectFactory.CreateAndDestroy(VisualEffectId.HenExplosion, transform.position, Quaternion.identity);
    }
  }
}