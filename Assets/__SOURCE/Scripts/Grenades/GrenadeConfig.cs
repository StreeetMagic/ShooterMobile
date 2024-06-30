using UnityEngine;

namespace Grenades
{
  [CreateAssetMenu(fileName = nameof(GrenadeConfig), menuName = "Configs/GrenadeConfig")]
  public class GrenadeConfig : ScriptableObject
  {
    [Tooltip("Идентификатор")]
    public GrenadeTypeId TypeId;
    
    [Tooltip("Время полета от запуска до приземления")]
    public float FlightTime = 1f;
    
    [Tooltip("Время детонации после приземления")]
    public float DetonationTime = 1f;
    
    [Tooltip("Радиус детонации")]
    public float DetonationRadius = 1f;
    
    [Tooltip("Урон")]
    public float Damage = 50;
  }
}