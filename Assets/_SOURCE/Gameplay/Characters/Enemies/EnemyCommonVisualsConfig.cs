using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  [CreateAssetMenu(menuName = "ArtConfigs/EnemyVisualsConfig", fileName = "EnemyVisualsConfig")]
  public class EnemyCommonVisualsConfig : ScriptableObject
  {
    [Tooltip("Материал, на который нужно поменять")]
    public Material NewMaterial;  
    
    [Tooltip("Промежуточный материал")]
    public Material TransitionMaterial; 
    
    [Tooltip("Время, сколько будет первый материал")]
    public float DurationFirstMaterial; 
    
    [Tooltip("Время перехода ко второму материалу")]
    public float TransitionDuration; 
    
    [Tooltip("Время, сколько будет второй материал")]
    public float DurationSecondMaterial;
  }
}