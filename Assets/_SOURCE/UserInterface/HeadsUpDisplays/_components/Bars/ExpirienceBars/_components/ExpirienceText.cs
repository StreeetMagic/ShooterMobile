using Gameplay.CurrencyRepositories.Expirience;
using Infrastructure.StaticDataServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.ExpirienceBars._components
{
  public class ExpirienceText : MonoBehaviour
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
      SetText(_expierienceStorage.CurrentExpierience());
      _expierienceStorage.AllPoints.ValueChanged += SetText;
    }

    private void OnDisable()
    {
      _expierienceStorage.AllPoints.ValueChanged -= SetText;
    }

    private void SetText(int value)
    {
      int currentExpierience = _expierienceStorage.CurrentExpierience();
      int expierienceToNextLevel = _expierienceStorage.ExpierienceToNextLevel();

      Text.text = $"{currentExpierience}/{expierienceToNextLevel} exp";
    
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