using Infrastructure.ZenjectFactories;
using Vlad.HeadsUpDisplays.UpgrageWindows;

namespace CodeBase.UI.Services.Windows
{
  public class WindowFactory
  {
    private readonly IZenjectFactory _factory;

    public WindowFactory(IZenjectFactory factory)
    {
      _factory = factory;
    }

    public void Open(WindowId windowId)
    {
      switch (windowId)
      {
        case WindowId.Unknown:
          break;

        case WindowId.UpgradeShop:
          _factory.Instantiate<UpgradeShopWindow>();
          break;
      }
    }
  }

  public enum WindowId
  {
    Unknown = 0,
    UpgradeShop = 1
  }
}