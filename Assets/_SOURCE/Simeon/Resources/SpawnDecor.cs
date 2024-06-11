using UnityEngine;
using System.Collections.Generic;

public class SpawnDecor : MonoBehaviour
{
  public GameObject[] objects;
  public Transform[] spawnPoints;
  public int minObjects, maxObjects;

  float[] objectProbabilities;
  List<Transform> availableSpawnPoints;
  int currentObjectsCount;

  void Start()
  {
    objectProbabilities = new float[objects.Length];

    for (int i = 0; i < objects.Length; i++)
    {
      objectProbabilities[i] = 1.0f; // Здесь можно задать вероятности для каждого объекта
    }

    availableSpawnPoints = new List<Transform>(spawnPoints);
    currentObjectsCount = 0;

    InvokeRepeating("SpawnObjectsMethod", 0, 1); // Запуск спавна каждую секунду
  }

  void SpawnObjectsMethod()
  {
    if (currentObjectsCount < maxObjects)
    {
      int numObjects = Random.Range(minObjects, Mathf.Min(maxObjects - currentObjectsCount + 1, availableSpawnPoints.Count));

      for (int i = 0; i < numObjects && availableSpawnPoints.Count > 0; i++)
      {
        int objectIndex = ChooseObject();
        int spawnPointIndex = Random.Range(0, availableSpawnPoints.Count);

        GameObject spawnedObject = Instantiate(objects[objectIndex], availableSpawnPoints[spawnPointIndex].position,
          availableSpawnPoints[spawnPointIndex].rotation, transform);

        // Удаление использованной точки спавна
        if (availableSpawnPoints[spawnPointIndex] != null)
        {
          Destroy(availableSpawnPoints[spawnPointIndex].gameObject);
          availableSpawnPoints.RemoveAt(spawnPointIndex);
        }

        currentObjectsCount++;
      }
    }

    // Удаление всех оставшихся точек спавна
    foreach (Transform spawnPoint in availableSpawnPoints)
    {
      if (spawnPoint != null)
      {
        Destroy(spawnPoint.gameObject);
      }
    }
  }

  int ChooseObject()
  {
    float total = 0;

    for (int i = 0; i < objectProbabilities.Length; i++)
    {
      total += objectProbabilities[i];
    }

    float randomPoint = Random.value * total;

    for (int i = 0; i < objectProbabilities.Length; i++)
    {
      if (randomPoint < objectProbabilities[i])
      {
        return i;
      }
      else
      {
        randomPoint -= objectProbabilities[i];
      }
    }

    return objectProbabilities.Length - 1;
  }
}