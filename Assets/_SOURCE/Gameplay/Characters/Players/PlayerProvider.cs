namespace Gameplay.Characters.Players
{
  public class PlayerProvider
  {
    private Player _instance;

    public Player Instance
    {
      get => _instance;
      set => _instance = value;
    }
  }
}