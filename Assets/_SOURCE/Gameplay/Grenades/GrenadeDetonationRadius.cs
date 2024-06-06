using Gameplay.Grenades;
using UnityEngine;

public class GrenadeDetonationRadius : MonoBehaviour
{
  public void Init(GrenadeConfig config)
  {
    float radius = config.DetonationRadius;
    float localRaius = radius * 2;

    transform.localScale = new Vector3(localRaius, localRaius, localRaius);
  }
}