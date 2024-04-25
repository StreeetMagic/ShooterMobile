using System;
using System.Collections.Generic;
using Zenject.Source.Injection;
using Zenject.Source.Main;

namespace Zenject.Source.Providers.SubContainerCreators
{
    public interface ISubContainerCreator
    {
        DiContainer CreateSubContainer(List<TypeValuePair> args, InjectContext context, out Action injectAction);
    }
}
