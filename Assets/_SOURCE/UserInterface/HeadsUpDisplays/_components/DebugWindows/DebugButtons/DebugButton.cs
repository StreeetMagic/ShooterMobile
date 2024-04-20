using System.Collections;
using System.Collections.Generic;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DebugButton : MonoBehaviour
{
  public Button Button;

  private WindowService _windowService;

  [Inject]
  public void Construct(WindowService windowService)
  {
    _windowService = windowService;
  }
  
  private void Start()
  {
    Button.onClick.AddListener(OnClick);
  }
  
  public void OnClick()
  {
    _windowService.Create(WindowId.Debug);
  }
}