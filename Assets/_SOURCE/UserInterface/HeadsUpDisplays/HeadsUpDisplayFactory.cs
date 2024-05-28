using AssetProviders;
using UnityEngine;
using UserInterface.HeadsUpDisplays.BackpackBars;
using UserInterface.HeadsUpDisplays.Buttons.OpenQuestButtons;
using UserInterface.HeadsUpDisplays.Buttons.OpenShopButtons;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Joysticks;
using UserInterface.HeadsUpDisplays.Windows._Shops.UpgradeShopWindows;
using ZenjectFactories;

namespace UserInterface.HeadsUpDisplays
{
  public class HeadsUpDisplayFactory
  {
    private HeadsUpDisplay _instance;

    private readonly GameLoopZenjectFactory _factory;
    private readonly IAssetProvider _assetProvider;
    private readonly HeadsUpDisplayProvider _provider;

    public HeadsUpDisplayFactory(GameLoopZenjectFactory factory,
      IAssetProvider assetProvider,
      HeadsUpDisplayProvider provider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _provider = provider;
    }

    public void Create(Transform parent)
    {
      HeadsUpDisplay prefab = _assetProvider.Get<HeadsUpDisplay>();
      _instance = _factory.InstantiateMono(prefab, parent);

      _provider.HeadsUpDisplay = _instance;
      _provider.CanvasTransform = _instance.GetComponentInChildren<RectTransform>();
      _provider.UpgradeShopButton = _instance.GetComponentInChildren<UpgradeShopWindowButton>();
      _provider.Borders = _instance.GetComponentInChildren<Borders>();
      _provider.FloatingJoystick = _instance.GetComponentInChildren<FloatingJoystick>();
      _provider.LootSlotsUpdater = _instance.GetComponentInChildren<LootSlotsUpdater>();
      _provider.OpenQuestButton = _instance.GetComponentInChildren<OpenQuestButton>();
      _provider.OpenShopButton = _instance.GetComponentInChildren<OpenShopButton>();
      _provider.BackpackBarFiller = _instance.GetComponentInChildren<BackpackBarFiller>();
      _provider.BaseTriggerTarget = _instance.GetComponentInChildren<BaseTriggerTarget>();
      _provider.ResourcesSendersContainer = _instance.GetComponentInChildren<ResourcesSendersContainer>();

      _instance.transform.parent = null;
    }

    public void Destroy()
    {
      Object.Destroy(_instance.gameObject);

      _provider.HeadsUpDisplay = null;
      _provider.UpgradeShopButton = null;
      _provider.Borders = null;
      _provider.FloatingJoystick = null;
      _provider.LootSlotsUpdater = null;
      _provider.OpenQuestButton = null;
      _provider.OpenShopButton = null;
      _provider.CanvasTransform = null;
      _provider.BackpackBarFiller = null;
      _provider.BaseTriggerTarget = null;
      _provider.ResourcesSendersContainer = null;

      _instance = null;
    }
  }
}