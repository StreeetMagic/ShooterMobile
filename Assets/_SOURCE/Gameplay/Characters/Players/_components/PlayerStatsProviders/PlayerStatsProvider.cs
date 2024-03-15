using Infrastructure.Utilities;

namespace Gameplay.Characters.Players._components.PlayerStatsServices
{
  public class PlayerStatsProvider
  {
    public ReactiveProperty<int> BackpackCapacity { get; } = new(10);
  }
}