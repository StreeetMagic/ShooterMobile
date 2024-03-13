using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.DataRepositories
{
  [CreateAssetMenu(fileName = "LootConfig", menuName = "Configs/LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public LootId LootId;

    public List<LootValue> Values;
  }
}