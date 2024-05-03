using System.Collections.Generic;
using UnityEngine;

public class PetSpawnPointsContainer : MonoBehaviour
{
  public List<Transform> SpawnPoints;
  
  public Transform GetRandomSpawnPoint() => 
    SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)];
}