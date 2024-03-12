using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Gameplay.Currencies;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs.Resources.Upgrades
{
  [SuppressMessage("ReSharper", "MissingBlankLines")]
  [CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Configs/UpgradeConfig")]
  public class UpgradeConfig : ScriptableObject
  {
    [SerializeField] [Tooltip("Сортировка апгрейдов")]
    public int SortingOrder;

    [Space] [SerializeField] [Tooltip("Идентификатор апгрейда")]
    public UpgradeId Id;

    [Space] [SerializeField] [Tooltip("Название апгрейда")]
    public string Title;

    [Space] [SerializeField] [Tooltip("Описание апгрейда")]
    public string Description;

    [Space] [SerializeField] [Tooltip("Значения апгрейда")]
    public CurrencyId CurrencyId;

    [Space] [SerializeField] [Tooltip("Значения апгрейда")]
    private List<UpgradeValues> _values;
    public List<UpgradeValues> Values => _values.ToList();
  }
}