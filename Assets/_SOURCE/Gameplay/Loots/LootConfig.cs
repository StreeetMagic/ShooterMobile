using System.Collections.Generic;
using Gameplay.CurrencyRepositories;
using UnityEngine;

namespace Gameplay.Loots
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public CurrencyId Id;

    public List<Loot> Loots;
  }
}