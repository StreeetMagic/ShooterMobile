using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using UserInterface.HeadsUpDisplays._components.BackpackBars;
using UserInterface.HeadsUpDisplays._components.Buttons.OpenQuestButtons;
using UserInterface.HeadsUpDisplays._components.Buttons.OpenShopButtons;
using UserInterface.HeadsUpDisplays._components.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays._components.MobileJoysticks.Scripts.Joysticks;
using UserInterface.HeadsUpDisplays._components.ResourcesSenders;
using UserInterface.Windows.ShopWinsows.UpgradeShopWindows;

namespace UserInterface.HeadsUpDisplays
{
  public class HeadsUpDisplayFactory
  {
    private HeadsUpDisplay _instance;

    private readonly GameLoopZenjectFactory _factory;
    private readonly AssetProvider _assetProvider;
    private readonly HeadsUpDisplayProvider _provider;
    private readonly ArtConfigProvider _artConfigProvider;

    public HeadsUpDisplayFactory(GameLoopZenjectFactory factory,
      AssetProvider assetProvider,
      HeadsUpDisplayProvider provider, ArtConfigProvider artConfigProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _provider = provider;
      _artConfigProvider = artConfigProvider;
    }

    public void Create(Transform parent)
    {
      HeadsUpDisplay prefab = _artConfigProvider.GetPrefab(PrefabId.HeadsUpDisplay).GetComponent<HeadsUpDisplay>();
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