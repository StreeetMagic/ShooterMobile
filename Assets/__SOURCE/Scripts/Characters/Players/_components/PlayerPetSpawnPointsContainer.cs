using System.Collections.Generic;
using UnityEngine;

namespace Characters.Players._components
{
  public class PlayerPetSpawnPointsContainer : MonoBehaviour
  {
    public List<Transform> SpawnPoints;
  
    public Transform GetRandomSpawnPoint() => 
      SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)];
  }
}