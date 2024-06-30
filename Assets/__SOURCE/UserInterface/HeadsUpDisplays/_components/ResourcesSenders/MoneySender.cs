using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays.ResourcesSenders
{
  public class MoneySender : MonoBehaviour
  {
    public ParticleImage ParticleImage;
    public RectTransform StartPosition;
    public RectTransform TargetTransform;

    public void PlayParticle(int amount, Vector3 targetPosition)
    {
    }
  }
}