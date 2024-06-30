using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Zenject.Source.Main;

namespace Infrastructure.ZenjectFactories.ProjectContext
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(AssetProvider assetProvider, IInstantiator instantiator, ArtConfigProvider artConfigProvider) : base(assetProvider, instantiator, artConfigProvider)
    {
    }
  }
}