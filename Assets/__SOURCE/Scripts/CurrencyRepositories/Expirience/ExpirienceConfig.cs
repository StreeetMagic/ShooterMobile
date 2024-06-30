using System.Collections.Generic;
using UnityEngine;

namespace CurrencyRepositories.Expirience
{
  [CreateAssetMenu(menuName = "Configs/ExpirienceConfig", fileName = "ExpirienceConfig")]
  public class ExpirienceConfig : ScriptableObject
  {
    [Header("Это настройки количества опыта для получения следующего уровня")]
    public List<ExpirienceSetup> Levels;
  }
}