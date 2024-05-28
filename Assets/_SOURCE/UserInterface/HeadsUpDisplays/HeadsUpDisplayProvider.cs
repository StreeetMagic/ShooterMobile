using UnityEngine;
using UserInterface.HeadsUpDisplays.BackpackBars;
using UserInterface.HeadsUpDisplays.Buttons.OpenQuestButtons;
using UserInterface.HeadsUpDisplays.Buttons.OpenShopButtons;
using UserInterface.HeadsUpDisplays.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Joysticks;
using UserInterface.HeadsUpDisplays.Windows._Shops.UpgradeShopWindows;

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