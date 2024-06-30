using System;
using UnityEngine;

namespace Infrastructure.AssetProviders
{
  [CreateAssetMenu(fileName = "PrefabPathConfig", menuName = "ArtConfigs/PrefabPathConfig")]
  public class PrefabPathConfig : ScriptableObject
  {
    public PrefabPathSetup[] Prefabs;
  }

  public enum PrefabId
  {
    Unknown = 0,

    Bomb = 1,
    BotCamera = 2,
    Enemy = 3,
    EnemyLootSlot = 4,
    EnemyProjectile = 5,
    EnemySpawner = 6,
    Grenade = 7,
    Hen = 8,
    Player = 9,
    PlayerProjectile = 10,
    Quester = 11,
    QuestPointer = 12,
    Shoper = 13,
    SpawnPoint = 14,
    TopCamera = 15,
    
    DebugWindow = 16,
    EggCollection1 = 17,
    EggSender = 18,
    HeadsUpDisplay = 19,
    HenShopWindow = 20,
    LootSlot = 21,
    MoneyCollection1 = 22,
    MoneyCollection2 = 23,
    MoneyCollection3 = 24,
    MoneySender = 25,
    QuestWindow = 26,
    SettingsWindow = 27,
    UpgradeCell = 28,
    UpgradeShopWindow = 29,
    SubQuestSlot = 30,
    AudioSourceContainer = 31,
  }

  [Serializable]
  public class PrefabPathSetup
  {
    public PrefabId Id;
    public GameObject Prefab;
  }
}