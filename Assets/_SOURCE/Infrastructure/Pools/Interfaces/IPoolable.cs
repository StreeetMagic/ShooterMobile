using UnityEngine;

namespace Infrastructure.Pools.Interfaces
{
  public interface IPoolable<T> where T : MonoBehaviour, IPoolable<T>
  {
    public GameObject GameObject { get; }

    public void OnRelease();
    public void SetPool(IPool<T> ownerPool);
  }
}