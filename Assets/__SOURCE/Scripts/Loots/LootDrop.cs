using System;
using CurrencyRepositories;

namespace Loots
{
  [Serializable]
  public class LootDrop
  {
    public CurrencyId Id;
    public int Level;
  }
}