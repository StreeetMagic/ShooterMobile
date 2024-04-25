using Zenject.Source.Injection;

#if !NOT_UNITY3D

namespace Zenject.Source.Providers.PrefabProviders
{
    public interface IPrefabProvider
    {
        UnityEngine.Object GetPrefab(InjectContext context);
    }
}

#endif

