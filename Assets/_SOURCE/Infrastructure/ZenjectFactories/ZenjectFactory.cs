using Infrastructure.AssetProviders;
using UnityEngine;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories
{
  public abstract class ZenjectFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    public ZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator)
    {
      _instantiator = instantiator;
      _assetProvider = assetProvider;
    }

    public T InstantiateNative<T>() => _instantiator.Instantiate<T>();
    public T InstantiateNative<T>(params object[] args) => _instantiator.Instantiate<T>(args);

    public GameObject InstantiateGameObject(GameObject gameObject) => _instantiator.InstantiatePrefab(gameObject);
    public GameObject InstantiateGameObject(GameObject gameObject, Transform parent) => _instantiator.InstantiatePrefab(gameObject, parent);
    public GameObject InstantiateGameObject(GameObject gameObject, Vector3 position, Quaternion quaternion, Transform parent) => _instantiator.InstantiatePrefab(gameObject, position, quaternion, parent);

    public T InstantiateMono<T>() where T : MonoBehaviour => _instantiator.InstantiatePrefab(_assetProvider.Get<T>()).GetComponent<T>();
    public T InstantiateMono<T>(string path) where T : MonoBehaviour => _instantiator.InstantiatePrefab(_assetProvider.Get<T>(path)).GetComponent<T>();
    public T InstantiateMono<T>(T behaviour) where T : MonoBehaviour => _instantiator.InstantiatePrefab(behaviour).GetComponent<T>();
    public T InstantiateMono<T>(T behaviour, Transform parent) where T : MonoBehaviour => _instantiator.InstantiatePrefab(behaviour, parent).GetComponent<T>();
    public T InstantiateMono<T>(T behaviour, Vector3 position, Transform parent = null) where T : MonoBehaviour => _instantiator.InstantiatePrefab(behaviour, position, Quaternion.identity, parent).GetComponent<T>();
    public T InstantiateMono<T>(T behaviour, Vector3 position, Quaternion quaternion, Transform parent = null) where T : MonoBehaviour => _instantiator.InstantiatePrefab(behaviour, position, quaternion, parent).GetComponent<T>();

    public T InstantiateMono<T>(Transform parent) where T : MonoBehaviour
    {
      var monoBehaviour = _instantiator
        .InstantiatePrefab(_assetProvider.Get<T>(), parent)
        .GetComponent<T>();

      monoBehaviour.transform.SetParent(parent);

      return monoBehaviour;
    }

    public T InstantiateMono<T>(Vector3 position) where T : MonoBehaviour
    {
      var monoBehaviour = _instantiator
        .InstantiatePrefab(_assetProvider.Get<T>())
        .GetComponent<T>();

      monoBehaviour.transform.position = position;

      return monoBehaviour;
    }

    public T InstantiateMono<T>(Vector3 position, Transform parent) where T : MonoBehaviour
    {
      var monoBehaviour = _instantiator
        .InstantiatePrefab(_assetProvider.Get<T>(), parent)
        .GetComponent<T>();

      monoBehaviour.transform.position = position;

      return monoBehaviour;
    }
  }
}