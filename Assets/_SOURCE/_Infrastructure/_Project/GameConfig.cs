namespace Infrastructure.Games
{
  public class GameConfig
  {
    public int ThroneHealth { get; private set; } = 100;
    public float SpawnCooldown { get; private set; } = 1f;
    public int WaveMobCount { get; private set; } = 10;
  }
}