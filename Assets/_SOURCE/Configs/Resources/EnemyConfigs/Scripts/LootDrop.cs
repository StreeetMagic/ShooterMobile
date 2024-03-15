using System;
using Gameplay.Currencies;
using Infrastructure.DataRepositories;

[Serializable]
public class LootDrop
{
  public CurrencyId Id;
  public int Level;
}