using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
  public WeaponTypeId WeaponTypeId;
  
  public WeaponAttackTypeId WeaponAttackTypeId;
  
  public float BulletSpreadAngle;
  
  public int BulletsPerShot;
  
  public int FireRate;
}