using UserInterface.HeadsUpDisplays.LootSlotsUpdaters;
using UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Joysticks;
using UserInterface.HeadsUpDisplays.OpenQuestButtons;
using UserInterface.HeadsUpDisplays.UpgradeShopWindows;

namespace UserInterface.HeadsUpDisplays
{
  public class HeadsUpDisplayProvider
  {
    public HeadsUpDisplay HeadsUpDisplay { get; set; }
    public UpgradeShopWindowButton UpgradeShopButton { get; set; }
    public Borders Borders { get; set; }
    public FloatingJoystick FloatingJoystick { get; set; }
    public LootSlotsUpdater LootSlotsUpdater { get; set; }
    public OpenQuestButton OpenQuestButton { get; set; }
  }
}