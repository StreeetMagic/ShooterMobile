using Infrastructure.Services.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.MobileJoysticks
{
    public class MobileJoystick : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _jumpButton;

        private IInputService _inputService;

        private void Awake()
        {
        }
    }
}