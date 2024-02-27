using System.Collections.Generic;
using System.Linq;
using _SOURCE.Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.Services.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private PlayerConfig _playerConfig;
    private bool _enemyLoaded;

    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;

    public PlayerConfig ForPlayer() =>
      _playerConfig ??= Resources.Load<PlayerConfig>(nameof(PlayerConfig));

    public EnemyConfig ForEnemy(EnemyId enemyId) =>
      _enemyConfigs[enemyId];

    public void LoadConfigs()
    {
      LoadEnemyConfigs();
    }

    private void LoadEnemyConfigs() =>
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>("Enemies")
        .ToDictionary(x => x.Id, x => x);
  }
}