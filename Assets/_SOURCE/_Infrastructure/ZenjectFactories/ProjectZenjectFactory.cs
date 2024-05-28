using _Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace _Infrastructure.ZenjectFactories
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}