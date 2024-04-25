using Zenject.Source.Binding.Binders.Factory.FactoryArgumentsToChoiceBinder;
using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Main;

namespace Zenject.Source.Binding.Binders.Factory.Pooling
{
    [NoReflectionBaking]
    public class MemoryPoolExpandBinder<TContract> : FactoryArgumentsToChoiceBinder<TContract>
    {
        public MemoryPoolExpandBinder(
            DiContainer bindContainer, BindInfo.BindInfo bindInfo, FactoryBindInfo factoryBindInfo, MemoryPoolBindInfo poolBindInfo)
            : base(bindContainer, bindInfo, factoryBindInfo)
        {
            MemoryPoolBindInfo = poolBindInfo;

            ExpandByOneAtATime();
        }

        protected MemoryPoolBindInfo MemoryPoolBindInfo
        {
            get; private set;
        }

        public FactoryArgumentsToChoiceBinder<TContract> ExpandByOneAtATime()
        {
            MemoryPoolBindInfo.ExpandMethod = PoolExpandMethods.OneAtATime;
            return this;
        }

        public FactoryArgumentsToChoiceBinder<TContract> ExpandByDoubling()
        {
            MemoryPoolBindInfo.ExpandMethod = PoolExpandMethods.Double;
            return this;
        }
    }
}

