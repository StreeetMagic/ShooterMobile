using CurrencyRepositories.Expirience;
using StaticDataServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.ExpirienceBars._components
{
  public class CurrentExpirienceLevel : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    private ExpierienceStorage _expierienceStorage;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(ExpierienceStorage expierienceStorage, IStaticDataService staticDataService)
    {
      _expierienceStorage = expierienceStorage;
      _staticDataService = staticDataService;
    }
  
    private ExpirienceConfig Config => _staticDataService.GetExpirienceConfig();

    private void OnEnable()
    {
      SetText(_expierienceStorage.CurrentLevel());
      _expierienceStorage.AllPoints.ValueChanged += SetText;
    }

    private void OnDisable()
    {
      _expierienceStorage.AllPoints.ValueChanged -= SetText;
    }

    private void SetText(int value)
    {
      Text.text = _expierienceStorage.CurrentLevel().ToString();
      SetColor();
    }
  
    private void SetColor()
    {
      int currentLevel = _expierienceStorage.CurrentLevel();
      Color newColor = Config.Levels[currentLevel - 1].Color;
      newColor.a = 255;

      if (Text.color != newColor)
        Text.color = newColor;
    }
  }
}