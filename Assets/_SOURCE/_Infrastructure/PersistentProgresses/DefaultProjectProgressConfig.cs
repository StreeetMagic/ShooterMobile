using UnityEngine;

namespace PersistentProgresses
{
  [CreateAssetMenu(fileName = "DefaultProjectProgressConfig", menuName = "Configs/DefaultProjectProgressConfig")]
  public class DefaultProjectProgressConfig : ScriptableObject
  {
    public int MoneyInBank = 100;
    public int EggsInBank;
    public Vector3 PlayerPosition = Vector3.zero;
    public int Expierience;
    public bool MusicMute;
  }
}