using CurrencyRepositories.Expirience;
using Infrastructure.ConfigProviders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.Bars.ExpirienceBars._components
{
  public class ExpirienceBar : MonoBehaviour
  {
    public Slider Slider;

    [Inject] private ExpierienceStorage _expierienceStorage;
    [Inject] private ConfigProvider _configProvider;

    private ExpirienceConfig Config => _configProvider.ExpirienceConfig;

    private void Update()
    {
     //SetColor();

      float expierienceToNextLevel = (float)_expierienceStorage.CurrentExpierience() / _expierienceStorage.ExpierienceToNextLevel();

      Slider.value =
        Slider.value > expierienceToNextLevel
          ? expierienceToNextLevel
          : Mathf.MoveTowards(Slider.value, expierienceToNextLevel, Time.deltaTime);
    }

    private void SetColor()
    {
      // int currentLevel = _expierienceStorage.CurrentLevel();
      // Color newColor = Config.Levels[currentLevel - 1].Color;
      // newColor.a = 255;
      //
      // if (Image.color != newColor)
      //   Image.color = newColor;
    }
  }
}