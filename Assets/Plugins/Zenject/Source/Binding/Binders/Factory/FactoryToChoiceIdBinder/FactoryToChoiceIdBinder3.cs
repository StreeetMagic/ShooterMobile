using Zenject.Source.Binding.Binders.Factory.FactoryArgumentsToChoiceBinder;
using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Main;

namespace Zenject.Source.Binding.Binders.Factory.FactoryToChoiceIdBinder
{
    [NoReflectionBaking]
    public class FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract> : FactoryArgumentsToChoiceBinder<TParam1, TParam2, TParam3, TContract>
    {
        public FactoryToChoiceIdBinder(
            DiContainer bindContainer, BindInfo.BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(bindContainer, bindInfo, factoryBindInfo)
        {
        }

        public FactoryArgumentsToChoiceBinder<TParam1, TParam2, TParam3, TContract> WithId(object identifier)
        {
            BindInfo.Identifier = identifier;
            return this;
        }
    }
}


