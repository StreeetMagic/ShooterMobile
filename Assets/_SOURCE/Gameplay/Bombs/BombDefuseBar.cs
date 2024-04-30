using System;
using UnityEngine;
using UnityEngine.UI;

public class BombDefuseBar : MonoBehaviour
{
  public Slider Slider;

  public BombDefuser BombDefuser;

  private void Update()
  {
    Slider.value = BombDefuser.DefuseProgress;
  }
}