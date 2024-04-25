using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using DataRepositories.BackpackStorages;
using UnityEngine;

namespace Configs.Resources.LootConfigs
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public CurrencyId Id;
    public Sprite Icon;

    public List<Loot> Loots;
  }
}