using System.Collections.Generic;
using Scripts;

namespace Infrastructure.Projects
{
  public class ProjectData
  {
    public SceneId InitialSceneId { get; set; }
    public GameMode GameMode { get; set; }

    private readonly Dictionary<SceneId, GameLoopSceneTypeId> _scenes = new()
    {
      { SceneId.CoreDust, GameLoopSceneTypeId.Core },
      { SceneId.VladTestScene, GameLoopSceneTypeId.Core },
      { SceneId.SimeonTestScene, GameLoopSceneTypeId.Core },
      { SceneId.ValeraTestScene, GameLoopSceneTypeId.Core },

      { SceneId.ArenaSand, GameLoopSceneTypeId.Arena },
      { SceneId.ArenaSnow, GameLoopSceneTypeId.Arena },
      { SceneId.ArenaStone, GameLoopSceneTypeId.Arena },

      { SceneId.Unknown, GameLoopSceneTypeId.Infrastructure },
      { SceneId.Initial, GameLoopSceneTypeId.Infrastructure },
      { SceneId.Empty, GameLoopSceneTypeId.Infrastructure },
      { SceneId.LoadConfigs, GameLoopSceneTypeId.Infrastructure },
      { SceneId.LoadProgress, GameLoopSceneTypeId.Infrastructure },
      { SceneId.ChooseGameMode, GameLoopSceneTypeId.Infrastructure },
    };

    public GameLoopSceneTypeId GetGameLoopSceneTypeId(SceneId sceneId) =>
      _scenes[sceneId];
  }
}