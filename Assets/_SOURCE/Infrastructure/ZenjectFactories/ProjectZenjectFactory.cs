using Infrastructure.AssetProviders;
using Zenject;

namespace Infrastructure.ZenjectFactories
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(IAssetProvider assetProvider, IInstantiator instantiator) : base(assetProvider, instantiator)
    {
    }
  }
}