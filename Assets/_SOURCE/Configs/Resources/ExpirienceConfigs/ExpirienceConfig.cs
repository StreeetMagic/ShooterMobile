using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Resources.ExpirienceConfigs
{
  [CreateAssetMenu(menuName = "Configs/ExpirienceConfig", fileName = "ExpirienceConfig")]
  public class ExpirienceConfig : ScriptableObject
  {
    public List<ExpirienceSetup> Levels;
  }

  [Serializable]
  public class ExpirienceSetup
  {
    public int Level;
    public int Expierience;
  }
}