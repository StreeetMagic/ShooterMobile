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
  public class HeadsUpDisplayProvider
  {
    public RectTransform CanvasTransform { get; set; }
    public HeadsUpDisplay HeadsUpDisplay { get; set; }
    public UpgradeShopWindowButton UpgradeShopButton { get; set; }
    public Borders Borders { get; set; }
    public FloatingJoystick FloatingJoystick { get; set; }
    public LootSlotsUpdater LootSlotsUpdater { get; set; }
    public OpenQuestButton OpenQuestButton { get; set; }
    public OpenShopButton OpenShopButton { get; set; }
    public BackpackBarFiller BackpackBarFiller { get; set; }
    public BaseTriggerTarget BaseTriggerTarget { get; set; }
    public ResourcesSendersContainer ResourcesSendersContainer { get; set; }
  }
}