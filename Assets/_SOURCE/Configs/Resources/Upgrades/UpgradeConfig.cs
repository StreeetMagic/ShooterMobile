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
    private const int Space = 10;
  
    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(1)]
    [ShowInInspector, PropertyTooltip("Порядковый номер для показа в списке в магазине")]
    public int SortingOrder { get; private set; }

    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(2)]
    [ShowInInspector, PropertyTooltip("Тип апгрейда")]
    public UpgradeId Id { get; private set; }

    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(3)]
    [ShowInInspector, PropertyTooltip("Название апгрейда")]
    public string Title { get; private set; }

    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(5)]
    [ShowInInspector, PropertyTooltip("Описание апгрейда")]
    public string Description { get; private set; }

    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(6)]
    [ShowInInspector, PropertyTooltip("Начальное значение апгрейда")]
    public int InitialValue { get; private set; }

    [PropertyOrder(7)]
    [ShowInInspector, PropertyTooltip("Тип валюты для апгрейда")]
    public CurrencyId CurrencyId { get; private set; }

    [PropertySpace(SpaceBefore = Space, SpaceAfter = Space)]
    [PropertyOrder(8)] 
    [SerializeField] 
    [Tooltip(" Набор апгрейдов")]
    private List<UpgradeValues> _values;
    public List<UpgradeValues> Values => _values.ToList();
  }
}