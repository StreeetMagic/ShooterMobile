using System.Collections.Generic;
using Loots;
using UnityEngine;

namespace Bombs
{
  public class Bomb : MonoBehaviour
  {
    public BombDefuser Defuser;
    public List<LootDrop> LootDrops { get; set; }
  }
}