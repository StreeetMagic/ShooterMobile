using Infrastructure.Games;
using Infrastructure.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VladTestButton : MonoBehaviour
{
  public Button Button;

  [Inject] private SceneLoader _sceneLoader;

  private void Start()
  {
    Button.onClick.AddListener(() => { _sceneLoader.Load(ProjectConstants.Scenes.VladTestScene); });
  }
}