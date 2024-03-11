using UnityEngine.EventSystems;
using UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Base;

namespace UserInterface.HeadsUpDisplays.MobileJoysticks.ImportedJoystickPack.FloatingJoysticks.Scripts.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}