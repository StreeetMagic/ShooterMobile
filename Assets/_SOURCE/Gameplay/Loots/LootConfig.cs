using System.Collections.Generic;
using Gameplay.CurrencyRepositories;
using Gameplay.CurrencyRepositories.BackpackStorages;
using UnityEngine;

namespace Gameplay.Loots
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public CurrencyId Id;
    public Sprite Icon;

    public List<Loot> Loots;
  }
}