using System.Collections.Generic;
using System.Linq;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.SoundConfigs;
using Configs.Resources.SoundConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Gameplay.Currencies;
using Infrastructure.DataRepositories;
using UnityEngine;

namespace Infrastructure.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private const string PlayerConfigPath = "PlayerConfigs/PlayerConfig";
    private const string EnemyConfigPath = "EnemyConfigs";
    private const string UpgradeConfigPath = "UpgradeConfigs";
    private const string SoundConfigPath = "SoundConfigs";
    private const string LootConfigPath = "LootConfigs";
    private const string MusicConfigPath = "MusicConfigs";

    private PlayerConfig _playerConfig;
    private bool _enemyLoaded;

    private Dictionary<EnemyId, EnemyConfig> _enemyConfigs;
    private Dictionary<StatId, UpgradeConfig> _upgradeConfigs;
    private Dictionary<CurrencyId, LootConfig> _lootConfigs;
    private Dictionary<MusicId, MusicConfig> _musicConfigs;
    private Dictionary<SoundId, SoundConfig> _soundConfigs;
    private Dictionary<StatId, int> _stats;

    public PlayerConfig GetPlayerConfig() =>
      _playerConfig ??= Resources.Load<PlayerConfig>(PlayerConfigPath);

    public EnemyConfig GetEnemyConfig(EnemyId enemyId) =>
      _enemyConfigs[enemyId];

    public Dictionary<StatId, UpgradeConfig> GetUpgradeConfigs() =>
      _upgradeConfigs;

    public UpgradeConfig GetUpgradeConfig(StatId id) =>
      _upgradeConfigs[id];

    public LootConfig GetLootConfig(CurrencyId lootDropId) =>
      _lootConfigs[lootDropId];

    public MusicConfig GetMusicConfig(MusicId musicId) =>
      _musicConfigs[musicId];

    public SoundConfig GetSoundConfig(SoundId soundId) =>
      _soundConfigs[soundId];

    public int GetInitialStat(StatId id) =>
      _stats[id];

    public void LoadConfigs()
    {
      LoadEnemyConfigs();
      LoadUpgradeConfigs();
      LoadLootConfigs();
      LoadMusicConfigs();
      LoadSoundConfigs();
      LoadInitialStats();
    }

    private void LoadInitialStats()
    {
      List<PlayerConfig.StatValuePair> stats = Resources.Load<PlayerConfig>(PlayerConfigPath).Stats;

      _stats = new Dictionary<StatId, int>();

      foreach (PlayerConfig.StatValuePair stat in stats)
        _stats.Add(stat.StatId, stat.Value);
    }

    private void LoadUpgradeConfigs() =>
      _upgradeConfigs = Resources
        .LoadAll<UpgradeConfig>(UpgradeConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadEnemyConfigs() =>
      _enemyConfigs = Resources
        .LoadAll<EnemyConfig>(EnemyConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadLootConfigs() =>
      _lootConfigs = Resources
        .LoadAll<LootConfig>(LootConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadMusicConfigs() =>
      _musicConfigs = Resources
        .LoadAll<MusicConfig>(MusicConfigPath)
        .ToDictionary(x => x.Id, x => x);

    private void LoadSoundConfigs() =>
      _soundConfigs = Resources
        .LoadAll<SoundConfig>(SoundConfigPath)
        .ToDictionary(x => x.Id, x => x);
  }
}