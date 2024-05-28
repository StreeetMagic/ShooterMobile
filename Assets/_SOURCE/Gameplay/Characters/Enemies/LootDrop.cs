using System;
using CurrencyRepositories;

namespace Gameplay.Characters.Enemies
{
  [Serializable]
  public class LootDrop
  {
    public CurrencyId Id;
    public int Level;
  }
}