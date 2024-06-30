using System;
using Stats;
using UnityEngine;

namespace Upgrades
{
  [Serializable]
  public class UpgradeContentSetup
  {
    [Tooltip("Идентификатор апгрейда")]
    public StatId Id;

    [Tooltip("Название апгрейда")] 
    public string Title;

    [Tooltip("Описание апгрейда")] 
    public string Description;

    [Tooltip("Иконка")] 
    public Sprite Icon;
  }
}