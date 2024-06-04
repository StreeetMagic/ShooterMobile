using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
  public WeaponTypeId WeaponTypeId;
  public float BulletSpreadAngle;
}