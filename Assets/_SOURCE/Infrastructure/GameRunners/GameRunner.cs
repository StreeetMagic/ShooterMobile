using Infrastructure.GameBootstrappers;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Infrastructure.GameRunners
{
  public class GameRunner : MonoBehaviour
  {
    [SerializeField] private GameBootstrapper _bootstrapperPrefab;

    private ProjectZenjectFactory _factory;

    [Inject]
    public void Construct(ProjectZenjectFactory factory)
    {
      _factory = factory;
    }

    private void Awake()
    {
      CreateBootstrapper();
    }

    private void CreateBootstrapper()
    {
      if (FindObjectOfType<GameBootstrapper>() == null)
        _factory.InstantiateMono(_bootstrapperPrefab);

      Destroy(gameObject);
    }
  }
}