using System;
using UnityEngine;

namespace Gameplay.Bombs
{
  public class BombDefuser : MonoBehaviour
  {
    public Bomb Bomb;
    
    public event Action<BombDefuser> Defused;

    public float DefuseProgress { get; set; }
    public bool IsDefused { get; set; }

    private void Update()
    {
      if (IsDefused)
        return;
      
      if (DefuseProgress >= 1)
      {
        IsDefused = true;
        Defused?.Invoke(this);
      }
    }
  }
}