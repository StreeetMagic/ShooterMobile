using Gameplay.CurrencyRepositories.Expirience;
using Infrastructure.ConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Bars.ExpirienceBars
{
  public class ExpirienceBar : MonoBehaviour
  {
    public Image Image;

    [Inject] private ExpierienceStorage _expierienceStorage;
    [Inject] private ConfigProvider _configProvider;

    private ExpirienceConfig Config => _configProvider.ExpirienceConfig;

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