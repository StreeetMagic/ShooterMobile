using System;
using System.Collections.Generic;
using Gameplay.Loots;
using Gameplay.RewardServices;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using Maps;
using Maps.Markers.SubQuestMarkers.BombDefuse;
using UnityEngine;
using Zenject;

namespace Gameplay.Bombs
{
  public class BombSpawner : MonoBehaviour
  {
    [Inject] private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;
    [Inject] private readonly MapProvider _mapProvider;
    [Inject] private readonly RewardService _rewardServices;

    private readonly List<BombDefuseSetup> _bombDefuseSetups = new();

    public List<Bomb> Bombs { get; } = new();

    private void Update()
    {
      List<BombDefuseSetup> setupsToRemove = new();

      foreach (BombDefuseSetup bombDefuseSetup in _bombDefuseSetups)
      {
        bombDefuseSetup.RespawnTimeLeft -= Time.deltaTime;

        if (bombDefuseSetup.RespawnTimeLeft <= 0)
        {
          SpawnBomb(bombDefuseSetup.Position, bombDefuseSetup.RespawnTime, bombDefuseSetup.LootDrops);
          setupsToRemove.Add(bombDefuseSetup);
        }
      }

      foreach (BombDefuseSetup setup in setupsToRemove)
        _bombDefuseSetups.Remove(setup);
    }

    public void SpawnBombs()
    {
      foreach (BombDefuseMarker marker in _mapProvider.Map.BombDefuseMarkers)
        SpawnBomb(marker.transform.position, marker.RespawnTime, marker.LootDrops);
    }

    private void SpawnBomb(Vector3 position, float respawnTime, List<LootDrop> lootDrops)
    {
      Bomb bomb = CreateBomb(position);

      if (lootDrops == null)
        throw new Exception("В бомбе не установлен дроп");

      bomb.LootDrops = new List<LootDrop>(lootDrops);
      bomb.Defuser.Defused += DestroyBomb;
      bomb.Defuser.RespawnTime = respawnTime;
      Bombs.Add(bomb);
    }

    private Bomb CreateBomb(Vector3 position)
    {
      //return _gameLoopZenjectFactory.InstantiateMono<Bomb>(position);
      var component = _gameLoopZenjectFactory.InstantiateGameObject(PrefabId.Bomb).GetComponent<Bomb>();
      component.transform.position = position;
      return component;
    }

    private void DestroyBomb(BombDefuser defuser)
    {
      Bomb defusedBomb = defuser.Bomb;
      defusedBomb.Defuser.Defused -= DestroyBomb;
      Bombs.Remove(defusedBomb);

      _bombDefuseSetups.Add(new BombDefuseSetup(defusedBomb.transform.position, defuser.RespawnTime, defusedBomb.LootDrops));
      _rewardServices.OnLootDroped(defusedBomb.LootDrops);

      Destroy(defusedBomb.gameObject);
    }

    private class BombDefuseSetup
    {
      public readonly Vector3 Position;
      public readonly float RespawnTime;
      public float RespawnTimeLeft;
      public List<LootDrop> LootDrops;

      public BombDefuseSetup(Vector3 position, float respawnTime, List<LootDrop> lootDrops)
      {
        Position = position;
        RespawnTime = respawnTime;
        LootDrops = lootDrops;
        RespawnTimeLeft = respawnTime;
      }
    }
  }
}