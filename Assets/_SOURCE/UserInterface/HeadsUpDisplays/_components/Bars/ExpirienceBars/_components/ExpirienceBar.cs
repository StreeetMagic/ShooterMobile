using CurrencyRepositories.Expirience;
using StaticDataServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.ExpirienceBars._components
{
  public class ExpirienceBar : MonoBehaviour
  {
    public Image Image;

    [Inject] private ExpierienceStorage _expierienceStorage;
    [Inject] private IStaticDataService _staticDataService;

    private ExpirienceConfig Config => _staticDataService.GetExpirienceConfig();

    private void Update()
    {
      SetColor();

      float expierienceToNextLevel = (float)_expierienceStorage.CurrentExpierience() / _expierienceStorage.ExpierienceToNextLevel();

      Image.fillAmount =
        Image.fillAmount > expierienceToNextLevel
          ? expierienceToNextLevel
          : Mathf.MoveTowards(Image.fillAmount, expierienceToNextLevel, Time.deltaTime);
    }

    private void SetColor()
    {
      int currentLevel = _expierienceStorage.CurrentLevel();
      Color newColor = Config.Levels[currentLevel - 1].Color;
      newColor.a = 255;

      if (Image.color != newColor)
        Image.color = newColor;
    }
  }
}