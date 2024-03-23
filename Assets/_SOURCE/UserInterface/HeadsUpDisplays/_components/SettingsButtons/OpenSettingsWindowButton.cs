using System.Collections;
using System.Collections.Generic;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenSettingsWindowButton : MonoBehaviour
{
    public Button Button;
    
    private WindowFactory _windowFactory;
    
    [Inject]
    public void Construct(WindowFactory windowFactory)
    {
        _windowFactory = windowFactory;
        Button.onClick.AddListener(OnButtonClicked);
    }
    
    private void OnButtonClicked()
    {
        _windowFactory.Create(WindowId.Settings);
    }
}
