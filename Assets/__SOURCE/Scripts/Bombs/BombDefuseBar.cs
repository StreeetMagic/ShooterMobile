using UnityEngine;
using UnityEngine.UI;

namespace Bombs
{
  public class BombDefuseBar : MonoBehaviour
  {
    public Slider Slider;

    public BombDefuser BombDefuser;

    private void Update()
    {
      Slider.value = BombDefuser.DefuseProgress;
    }
  }
}