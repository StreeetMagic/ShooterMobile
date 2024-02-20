using Games;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameBootstrappers
{
  public class GameBootstrapper : MonoBehaviour
  {
    private IZenjectFactory _zenjectFactory;

    [Inject]
    public void Construct(IZenjectFactory zenjectFactory)
    {
      _zenjectFactory = zenjectFactory;
    }

    private void Awake()
    {
      var game = _zenjectFactory.Create<Game>();
      game.Start();
    }
  }
}