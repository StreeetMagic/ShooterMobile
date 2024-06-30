using System;
using Gameplay.CurrencyRepositories;
using UnityEngine;

namespace Gameplay.Loots
{
  [Serializable]
  public class LootContentSetup
  {
    public CurrencyId Id;
    public Sprite Sprite;
    
    public LootContentSetup(CurrencyId id, Sprite sprite)
    {
      Id = id;
      Sprite = sprite;
    }
  }
}