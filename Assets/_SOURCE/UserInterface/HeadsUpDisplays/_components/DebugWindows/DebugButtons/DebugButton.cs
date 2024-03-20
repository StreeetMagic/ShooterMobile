using System.Collections;
using System.Collections.Generic;
using Infrastructure.UserIntefaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DebugButton : MonoBehaviour
{
  public Button Button;

  private WindowFactory _windowFactory;

  [Inject]
  public void Construct(WindowFactory windowFactory)
  {
    _windowFactory = windowFactory;
  }
  
  private void Start()
  {
    Button.onClick.AddListener(OnClick);
  }
  
  public void OnClick()
  {
    _windowFactory.Create(WindowId.Debug);
  }
}