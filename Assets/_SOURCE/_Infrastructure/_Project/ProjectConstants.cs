namespace Infrastructure.Games
{
  public class ProjectConstants
  {
    public class CommonSettings
    {
      public const float BombDefuseRadius = 3f;
      public const float BombDefuseDuration = 3f;
    }

    public class Scenes
    {
      public const string Initial = nameof(Initial);
      public const string GameLoop = nameof(GameLoop);
      public const string Empty = nameof(Empty);
      public const string InitialSceneName = nameof(InitialSceneName);
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
        public const string Map = nameof(Map);
        public const string PlayerVlad = nameof(PlayerVlad);
      }
    }
  }
}