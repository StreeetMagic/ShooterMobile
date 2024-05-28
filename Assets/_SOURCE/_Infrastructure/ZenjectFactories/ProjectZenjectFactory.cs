using AssetProviders;
using Zenject.Source.Main;

namespace ZenjectFactories
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}