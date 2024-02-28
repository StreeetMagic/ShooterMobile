namespace Infrastructure.Games
{
  public class Constants
  {
    public class Scenes
    {
      public const string Initial = nameof(Initial);
      public const string GameLoop = nameof(GameLoop);
    }

    public class AssetsPath
    {
      public class Materials
      {
      }

      public class Prefabs
      {
        public const string CoroutineRunner = nameof(CoroutineRunner);
        public const string LoadingCurtain = nameof(LoadingCurtain);
        public const string MapVlad = nameof(MapVlad);
        public const string PlayerVlad = nameof(PlayerVlad);
      }
    }

    public class Ids
    {
      public const string InitialSceneName = nameof(InitialSceneName);
    }
  }
}