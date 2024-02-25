using Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

namespace Infrastructure.Services.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    public PlayerConfig ForPlayer() =>
      Resources.Load<PlayerConfig>(nameof(PlayerConfig));
  }
}