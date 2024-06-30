using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetProviders
{
  public class AssetProvider
  {
    // public T Get<T>() where T : MonoBehaviour
    // {
    //   if (Resources.Load(typeof(T).Name) == null)
    //     throw new Exception("Asset not found: " + typeof(T).Name);
    //
    //   var load = Resources.Load(typeof(T).Name).GetComponent<T>();
    //
    //   if (!load)
    //     throw new Exception("Asset not found: " + typeof(T).Name);
    //
    //   return load;
    // }
    //
    // public T Get<T>(string path) where T : MonoBehaviour
    // {
    //   var load = Resources.Load(path).GetComponent<T>();
    //
    //   if (!load)
    //     throw new Exception("Asset not found: " + path);
    //
    //   return load;
    // }

    public T GetScriptable<T>() where T : ScriptableObject
    {
      Object load = Resources.Load(typeof(T).Name);

      if (!load)
        throw new Exception("Asset not found: " + typeof(T).Name);

      return load as T;
    }

    public T GetScriptable<T>(string path) where T : ScriptableObject
    {
      Object load = Resources.Load(path);

      if (!load)
        throw new Exception("Asset not found: " + typeof(T).Name);

      return load as T;
    }

    public T[] GetAllScriptable<T>(string path) where T : ScriptableObject
    {
      T[] scriptableObjects = Resources.LoadAll<T>(path);

      if (scriptableObjects == null)
        throw new Exception("Assets not found: " + typeof(T).Name);

      return scriptableObjects;
    }

    public GameObject Get(string path)
    {
      Object load = Resources.Load(path);

      if (!load)
        throw new Exception("Asset not found: " + path);

      return load as GameObject;
    }
  }
}