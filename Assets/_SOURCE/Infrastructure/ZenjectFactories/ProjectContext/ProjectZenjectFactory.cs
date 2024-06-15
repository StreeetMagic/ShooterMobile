using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}