using UnityEngine;

namespace Infrastructure.ZenjectFactories
{
  public interface IZenjectFactory2
  {
    T Create<T>();

    GameObject InstantiateObject(GameObject gameObject);
    GameObject InstantiateObject(GameObject gameObject, Transform parent);
    GameObject InstantiateObject(GameObject gameObject, Vector3 position, Quaternion quaternion, Transform parent);

    TMono Instantiate<TMono>() where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(Transform parent) where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(TMono behaviour) where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(Vector3 position) where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(TMono behaviour, Transform parent) where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(TMono behaviour, Vector3 position, Transform parent = null) where TMono : MonoBehaviour;
    TMono Instantiate<TMono>(TMono behaviour, Vector3 position, Quaternion quaternion, Transform parent = null) where TMono : MonoBehaviour;
  }
}