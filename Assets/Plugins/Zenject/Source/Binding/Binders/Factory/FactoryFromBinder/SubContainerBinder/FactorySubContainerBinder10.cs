using System;
using Zenject.Source.Binding.Binders.GameObject;
using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Injection;
using Zenject.Source.Main;
using Zenject.Source.Providers;
using Zenject.Source.Providers.PrefabProviders;
using Zenject.Source.Providers.SubContainerCreators;

namespace Zenject.Source.Binding.Binders.Factory.FactoryFromBinder.SubContainerBinder
{
    [NoReflectionBaking]
    public class FactorySubContainerBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>
        : FactorySubContainerBinderWithParams<TContract>
    {
        public FactorySubContainerBinder(
            DiContainer bindContainer, BindInfo.BindInfo bindInfo, FactoryBindInfo factoryBindInfo, object subIdentifier)
            : base(bindContainer, bindInfo, factoryBindInfo, subIdentifier)
        {
        }

        public ScopeConcreteIdArgConditionCopyNonLazyBinder ByMethod(
#if !NET_4_6
            Internal.
#endif
            Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installerMethod)
        {
            var subcontainerBindInfo = new SubContainerCreatorBindInfo();

            ProviderFunc =
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(
                        container, subcontainerBindInfo, installerMethod), false);

            return new ScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo);
        }

#if !NOT_UNITY3D

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewGameObjectMethod(
#if !NET_4_6
            Internal.
#endif
            Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installerMethod)
        {
            var gameObjectInfo = new GameObjectCreationParameters();

            ProviderFunc =
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewGameObjectMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>( container,
                        gameObjectInfo, installerMethod), false);

            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabMethod(
            Func<InjectContext, UnityEngine.Object> prefabGetter,
#if !NET_4_6
            Internal.
#endif
            Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installerMethod)
        {
            var gameObjectInfo = new GameObjectCreationParameters();

            ProviderFunc =
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>( container,
                        new PrefabProviderCustom(prefabGetter),
                        gameObjectInfo, installerMethod), false);

            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabMethod(
            UnityEngine.Object prefab,
#if !NET_4_6
            Internal.
#endif
            Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installerMethod)
        {
            BindingUtil.AssertIsValidPrefab(prefab);

            var gameObjectInfo = new GameObjectCreationParameters();

            ProviderFunc =
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>( container,
                        new PrefabProvider(prefab),
                        gameObjectInfo, installerMethod), false);

            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }

        public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewPrefabResourceMethod(
            string resourcePath,
#if !NET_4_6
            Internal.
#endif
            Action<DiContainer, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> installerMethod)
        {
            BindingUtil.AssertIsValidResourcePath(resourcePath);

            var gameObjectInfo = new GameObjectCreationParameters();

            ProviderFunc =
                (container) => new SubContainerDependencyProvider(
                    ContractType, SubIdentifier,
                    new SubContainerCreatorByNewPrefabMethod<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>( container,
                        new PrefabProviderResource(resourcePath),
                        gameObjectInfo, installerMethod), false);

            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(BindInfo, gameObjectInfo);
        }
#endif
    }
}
