using Infrastructure.Pools.Interfaces;
using UnityEngine;

namespace Infrastructure.Pools
{
  public interface IPoolRepositoryService
  {
    public T Get<T>() where T : MonoBehaviour, IPoolable<T>;
    public void Release<T>(T obj) where T : MonoBehaviour, IPoolable<T>;
    public void Register<T>(IPool pool) where T : MonoBehaviour, IPoolable<T>;
    public void ReleaseAll<T>() where T : MonoBehaviour, IPoolable<T>;
    public void ReleaseAll();
  }
}