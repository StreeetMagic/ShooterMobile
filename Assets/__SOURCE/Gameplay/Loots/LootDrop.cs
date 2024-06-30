using System;
using Gameplay.CurrencyRepositories;

namespace Gameplay.Loots
{
  [Serializable]
  public class LootDrop
  {
    public CurrencyId Id;
    public int Level;
  }
}