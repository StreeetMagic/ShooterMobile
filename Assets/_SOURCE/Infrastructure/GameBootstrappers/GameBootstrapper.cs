using Infrastructure.Games;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameBootstrappers
{
  public class GameBootstrapper : MonoBehaviour
  {
    private IInstantiator _instantiator;

    [Inject]
    public void Construct(IInstantiator zenjectFactory)
    {
      _instantiator = zenjectFactory;
    }

    private void Awake()
    {
      var game = _instantiator.Instantiate<Game>();
      
      game.Start();
    }
  }
}