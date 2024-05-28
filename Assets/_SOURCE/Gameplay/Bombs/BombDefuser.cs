using System;
using UnityEngine;

namespace Gameplay.Bombs
{
  public class BombDefuser : MonoBehaviour
  {
    public event Action<BombDefuser> Defused;

    public float DefuseProgress { get; set; }
    public bool IsDefused { get; set; }

    private void Update()
    {
      if (DefuseProgress >= 1)
      {
        IsDefused = true;
        Defused?.Invoke(this);

        Destroy(gameObject);
      }
    }
  }
}