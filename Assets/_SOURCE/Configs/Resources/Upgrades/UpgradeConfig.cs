using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "Configs/UpgradeConfig")]
public class UpgradeConfig : ScriptableObject
{
  [field: SerializeField] public int SortingOrder { get; private set; }
  [field: SerializeField] public UpgradeId Id { get; private set; }
  [field: SerializeField] public string Title { get; private set; }
  [field: SerializeField] public string Description { get; private set; }
  [field: SerializeField] public int InitialValue { get; private set; }
  [SerializeField] private List<UpgradeValues> values;

  public List<UpgradeValues> Values => values.ToList();

  [Serializable]
  public class UpgradeValues
  {
    public int Number;
    public int Value;
  }
}