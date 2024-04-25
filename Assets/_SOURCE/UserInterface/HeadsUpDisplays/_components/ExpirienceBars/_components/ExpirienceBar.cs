using Configs.Resources.ExpirienceConfigs;
using DataRepositories;
using Infrastructure.StaticDataServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.ExpirienceBars._components
{
  public class ExpirienceBar : MonoBehaviour
  {
    public Image Image;

    private ExpierienceStorage _expierienceStorage;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(ExpierienceStorage expierienceStorage, IStaticDataService staticDataService)
    {
      _expierienceStorage = expierienceStorage;
      _staticDataService = staticDataService;
    }

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