using System.Collections.Generic;
using Gameplay.Loots;
using UnityEngine;

namespace Gameplay.Bombs
{
  public class Bomb : MonoBehaviour
  {
    public BombDefuser Defuser;
    public List<LootDrop> LootDrops { get; set; }
  }
}