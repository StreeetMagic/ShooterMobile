using Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

namespace Infrastructure.Services.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private PlayerConfig _playerConfig;

    public PlayerConfig ForPlayer() =>
      _playerConfig ??= Resources.Load<PlayerConfig>(nameof(PlayerConfig));
  }
}