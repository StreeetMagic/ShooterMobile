using System;
using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Main;

namespace Zenject.Source.Binding.Binders.Factory.FactoryFromBinder.Untyped
{
    [NoReflectionBaking]
    public class FactoryFromBinderUntyped : FactoryFromBinderBase
    {
        public FactoryFromBinderUntyped(
            DiContainer bindContainer, Type contractType, BindInfo.BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(bindContainer, contractType, bindInfo, factoryBindInfo)
        {
        }

        // TODO - add similar methods found in FactoryFromBinder<>
    }
}
