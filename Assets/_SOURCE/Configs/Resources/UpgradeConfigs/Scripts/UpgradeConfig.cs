using System.Collections.Generic;
using Configs.Resources.CurrencyConfigs;
using Configs.Resources.StatConfigs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs.Resources.UpgradeConfigs.Scripts
{
  [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Configs/UpgradeConfig")]
  public class UpgradeConfig : ScriptableObject
  {
    [Tooltip("Сортировка апгрейдов")] public int SortingOrder;

    [Space] [Tooltip("Идентификатор апгрейда")]
    public StatId Id;

    [Space] [Tooltip("Название апгрейда")] public string Title;

    [Space] [Tooltip("Описание апгрейда")] public string Description;

    [Space] [Tooltip("Значения апгрейда")] public CurrencyId CurrencyId;

    [Space] [Tooltip("Иконка")] public Sprite Icon;
    
    [Space] [Tooltip("Значения апгрейда")] public List<UpgradeValue> Values;

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