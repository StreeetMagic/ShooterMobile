using Infrastructure.ZenjectFactories;
using Vlad.HeadsUpDisplays;
using Vlad.HeadsUpDisplays.UpgrageWindows;

namespace CodeBase.UI.Services.Windows
{
  public class WindowFactory
  {
    private readonly IZenjectFactory _factory;
    private readonly HeadsUpDisplayProvider _headsUpDisplayProvider;

    public WindowFactory(IZenjectFactory factory, HeadsUpDisplayProvider headsUpDisplayProvider)
    {
      _factory = factory;
      _headsUpDisplayProvider = headsUpDisplayProvider;
    }

    public void Create(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.Unknown:
          break;

        case WindowId.UpgradeShop:
          _factory.Instantiate<UpgradeShopWindow>(_headsUpDisplayProvider.HeadsUpDisplayVlad.transform);
          break;
      }
    }
  }
}