using System.Collections.Generic;
using UnityEngine;

namespace CurrencyRepositories.Expirience
{
  [CreateAssetMenu(menuName = "Configs/ExpirienceConfig", fileName = "ExpirienceConfig")]
  public class ExpirienceConfig : ScriptableObject
  {
    public List<ExpirienceSetup> Levels;
  }
}