using System.Collections.Generic;
using CurrencyRepositories;
using Sirenix.OdinInspector;
using Stats;
using UnityEngine;

namespace Upgrades
{
  [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Configs/UpgradeConfig")]
  public class UpgradeConfig : ScriptableObject
  {
    [Space] [Tooltip("Идентификатор апгрейда")]
    public StatId Id;

    [Space] [Tooltip("Валюта покупки")] 
    public CurrencyId CurrencyId;
    
    [Space] [Tooltip("Значения апгрейда")] 
    public List<UpgradeValue> Values;

    [Button]
    private void SetTestValues()
    {
      Values = new List<UpgradeValue>();
      int level = 0;
      int value = 0;
      int cost = 0;

      for (int i = 0; i < 6; i++)
      {
        Values.Add(new UpgradeValue
        {
          Level = level++,
          Value = value += 10,
          Cost = cost += 8
        });
      }
    }
  }
}