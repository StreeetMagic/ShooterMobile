using Infrastructure.AssetProviders;
using UnityEngine;
using Zenject;

namespace Infrastructure.ZenjectFactories
{
  public class ZenjectFactory : IZenjectFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    public ZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator)
    {
      _instantiator = instantiator;
      _assetProvider = assetProvider;
    }

    public T Create<T>() =>
      _instantiator
        .Instantiate<T>();

    public GameObject Instantiate(GameObject gameObject) =>
      _instantiator
        .InstantiatePrefab(gameObject);

    public GameObject Instantiate(GameObject gameObject, Transform parent) =>
      _instantiator
        .InstantiatePrefab(gameObject, parent);

    public TMono Instantiate<TMono>() where TMono : MonoBehaviour =>
      _instantiator
        .InstantiatePrefab(_assetProvider.Get<TMono>())
        .GetComponent<TMono>();

    public TMono Instantiate<TMono>(Transform parent) where TMono : MonoBehaviour
    {
      var monoBehaviour = _instantiator
        .InstantiatePrefab(_assetProvider.Get<TMono>(), parent)
        .GetComponent<TMono>();

      monoBehaviour.transform.parent = parent;

      return monoBehaviour;
    }

    public TMono Instantiate<TMono>(TMono behaviour) where TMono : MonoBehaviour =>
      _instantiator
        .InstantiatePrefab(behaviour)
        .GetComponent<TMono>();

    public TMono Instantiate<TMono>(Vector3 position) where TMono : MonoBehaviour
    {
      var monoBehaviour = _instantiator
        .InstantiatePrefab(_assetProvider.Get<TMono>())
        .GetComponent<TMono>();

      monoBehaviour.transform.position = position;

      return monoBehaviour;
    }

    public TMono Instantiate<TMono>(TMono behaviour, Transform parent) where TMono : MonoBehaviour =>
      _instantiator
        .InstantiatePrefab(behaviour, parent)
        .GetComponent<TMono>();

    public TMono Instantiate<TMono>(TMono behaviour, Vector3 position, Transform parent = null) where TMono : MonoBehaviour =>
      _instantiator
        .InstantiatePrefab(behaviour, position, Quaternion.identity, parent)
        .GetComponent<TMono>();

    public TMono Instantiate<TMono>(TMono behaviour, Vector3 position, Quaternion quaternion, Transform parent = null) where TMono : MonoBehaviour =>
      _instantiator
        .InstantiatePrefab(behaviour, position, quaternion, parent)
        .GetComponent<TMono>();
  }
}