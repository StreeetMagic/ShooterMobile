using System;
using Gameplay.CurrencyRepositories;
using UnityEngine;

namespace Gameplay.Loots
{
  [Serializable]
  public class LootSpriteSetup
  {
    public CurrencyId Id;
    public Sprite Sprite;
    
    public LootSpriteSetup(CurrencyId id, Sprite sprite)
    {
      Id = id;
      Sprite = sprite;
    }
  }
}