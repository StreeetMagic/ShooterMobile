using System.Collections;
using System.Collections.Generic;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenSettingsWindowButton : MonoBehaviour
{
    public Button Button;
    
    private WindowService _windowService;
    
    [Inject]
    public void Construct(WindowService windowService)
    {
        _windowService = windowService;
        Button.onClick.AddListener(OnButtonClicked);
    }
    
    private void OnButtonClicked()
    {
        _windowService.Create(WindowId.Settings);
    }
}
