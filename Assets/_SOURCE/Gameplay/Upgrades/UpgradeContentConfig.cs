using System;
using System.Collections.Generic;
using Gameplay.Stats;
using UnityEngine;

namespace Gameplay.Upgrades
{
  [CreateAssetMenu(fileName = "UpgradeContentConfig", menuName = "ArtConfigs/UpgradeContentConfig")]
  public class UpgradeContentConfig : ScriptableObject
  {
    public List<UpgradeContentSetup> Setups;
  }

  [Serializable]
  public class UpgradeContentSetup
  {
    [Space] 
    [Tooltip("Идентификатор апгрейда")]
    public StatId Id;

    [Space] 
    [Tooltip("Название апгрейда")] 
    public string Title;

    [Space] 
    [Tooltip("Описание апгрейда")] 
    public string Description;

    [Space] 
    [Tooltip("Иконка")] 
    public Sprite Icon;
  }
}