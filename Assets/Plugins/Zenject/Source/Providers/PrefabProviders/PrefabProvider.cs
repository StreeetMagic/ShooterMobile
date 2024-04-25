#if !NOT_UNITY3D

using Zenject.Source.Injection;
using Zenject.Source.Internal;

namespace Zenject.Source.Providers.PrefabProviders
{
    [NoReflectionBaking]
    public class PrefabProvider : IPrefabProvider
    {
        readonly UnityEngine.Object _prefab;

        public PrefabProvider(UnityEngine.Object prefab)
        {
            Assert.IsNotNull(prefab);
            _prefab = prefab;
        }

        public UnityEngine.Object GetPrefab(InjectContext _)
        {
            return _prefab;
        }
    }
}

#endif


