using Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.MobileJoysticks.FixedJoysticks
{
    public class MobileJoystick : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _jumpButton;

        private IInputService _inputService;
    }
}