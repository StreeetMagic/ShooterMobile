using System;
using CurrencyRepositories;
using UnityEngine;

namespace Loots
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