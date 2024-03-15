using System.Collections.Generic;
using Gameplay.Currencies;
using UnityEngine;

namespace Infrastructure.DataRepositories
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public CurrencyId Id;
    public Sprite Icon;

    public List<Loot> Loots;
  }
}