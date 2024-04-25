using System;

namespace Zenject.OptionalExtras.Signals.Internal.Binders.DeclareSignal
{
    [NoReflectionBaking]
    public class SignalBindingBindInfo
    {
        public SignalBindingBindInfo(Type signalType)
        {
            SignalType = signalType;
        }

        public object Identifier
        {
            get; set;
        }

        public Type SignalType
        {
            get; private set;
        }
    }
}

