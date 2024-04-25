using Zenject.OptionalExtras.Signals.Internal.Binders.DeclareSignal;
using Zenject.Source.Main;

namespace Zenject.OptionalExtras.Signals.Internal.Binders.BindSignal
{
    public class BindSignalIdToBinder<TSignal> : BindSignalToBinder<TSignal>
    {
        public BindSignalIdToBinder(DiContainer container, SignalBindingBindInfo signalBindInfo)
            : base(container, signalBindInfo)
        {
        }

        public BindSignalToBinder<TSignal> WithId(object identifier)
        {
            SignalBindInfo.Identifier = identifier;
            return this;
        }
    }
}

