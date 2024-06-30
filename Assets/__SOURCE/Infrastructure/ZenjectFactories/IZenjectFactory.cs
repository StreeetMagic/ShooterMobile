using UnityEngine;

namespace Infrastructure.ZenjectFactories
{
  public interface IZenjectFactory
  {
    T InstantiateNative<T>();
    T InstantiateNative<T>(params object[] args);
    GameObject InstantiateGameObject(GameObject gameObject);
    GameObject InstantiateGameObject(GameObject gameObject, Transform parent);
    GameObject InstantiateGameObject(GameObject gameObject, Vector3 position, Quaternion quaternion, Transform parent);
    T InstantiateMono<T>() where T : MonoBehaviour;
    T InstantiateMono<T>(string path) where T : MonoBehaviour;
    T InstantiateMono<T>(T behaviour) where T : MonoBehaviour;
    T InstantiateMono<T>(T behaviour, Transform parent) where T : MonoBehaviour;
    T InstantiateMono<T>(T behaviour, Vector3 position, Transform parent = null) where T : MonoBehaviour;
    T InstantiateMono<T>(T behaviour, Vector3 position, Quaternion quaternion, Transform parent = null) where T : MonoBehaviour;
    T InstantiateMono<T>(Transform parent) where T : MonoBehaviour;
    T InstantiateMono<T>(Vector3 position) where T : MonoBehaviour;
    T InstantiateMono<T>(Vector3 position, Transform parent) where T : MonoBehaviour;
  }
}