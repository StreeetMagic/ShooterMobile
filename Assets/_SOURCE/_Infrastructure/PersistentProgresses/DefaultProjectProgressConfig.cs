using UnityEngine;

namespace PersistentProgresses
{
  [CreateAssetMenu(fileName = "DefaultProjectProgressConfig", menuName = "Configs/DefaultProjectProgressConfig")]
  public class DefaultProjectProgressConfig : ScriptableObject
  {
    [Tooltip("Начальное количество денег")] [Space]
    public int MoneyInBank = 100;

    [Tooltip("Начальное количество яиц")] [Space]
    public int EggsInBank;

    [Tooltip("Стартовая позиция игрока. Если по нулям - заспаунит в точке на карте, если выставлено - заспаунит в указанных координатах")] [Space]
    public Vector3 PlayerPosition = Vector3.zero;

    [Tooltip("Начальное количество опыта")] [Space]
    public int Expierience;

    [Tooltip("Включить/выключить музыку")] [Space]
    public bool MusicMute;
  }
}