using Zenject.Source.Binding.BindInfo;
using Zenject.Source.Main;

namespace Zenject.Source.Binding.Finalizers
{
    public interface IBindingFinalizer
    {
        BindingInheritanceMethods BindingInheritanceMethod
        {
            get;
        }

        void FinalizeBinding(DiContainer container);
    }
}
