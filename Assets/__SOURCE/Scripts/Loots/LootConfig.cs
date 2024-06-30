using System.Collections.Generic;
using CurrencyRepositories;
using UnityEngine;

namespace Loots
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public CurrencyId Id;

    public List<Loot> Loots;
  }
}