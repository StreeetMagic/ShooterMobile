using System;
using UnityEngine;

public class BombDefuser : MonoBehaviour
{
  public float DefuseProgress { get; set; }
  
  public event Action<BombDefuser> Defused;

  private void Update()
  {
    if (DefuseProgress >= 1)
    {
      Defused?.Invoke(this);
      
      Destroy(gameObject);
    }
  }
}
