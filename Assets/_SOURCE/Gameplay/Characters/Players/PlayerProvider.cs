namespace Gameplay.Characters.Players
{
  public class PlayerProvider
  {
    private PlayerInstaller _instance;

    public PlayerInstaller Instance
    {
      get => _instance;
      set => _instance = value;
    }
  }
}