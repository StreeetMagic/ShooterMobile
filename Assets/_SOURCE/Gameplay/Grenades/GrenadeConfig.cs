using UnityEngine;

namespace Gameplay.Grenades
{
  [CreateAssetMenu(fileName = nameof(GrenadeConfig), menuName = "Configs/GrenadeConfig")]
  public class GrenadeConfig : ScriptableObject
  {
    public GrenadeTypeId TypeId;
  }
}