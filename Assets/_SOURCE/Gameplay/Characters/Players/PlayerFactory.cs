using Infrastructure.AssetProviders;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories;
using Maps;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly PlayerProvider _playerProvider;
    private readonly SaveLoadService _saveLoadService;
    private readonly MapProvider _mapProvider;

    public PlayerFactory(GameLoopZenjectFactory factory, AssetProvider assetProvider,
      PlayerProvider playerProvider, SaveLoadService saveLoadService,
      MapProvider mapProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerProvider = playerProvider;
      _saveLoadService = saveLoadService;
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent)
    {
      var prefab = _assetProvider.Get<Player>();

      Player player = _factory.InstantiateMono(prefab, SpawnPosition(), parent);

      player.transform.SetParent(null);
      _playerProvider.Instance = player.GetComponent<PlayerInstaller>();

      foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
        _saveLoadService.ProgressReaders.Add(progressReader);
    }

    public void Destroy()
    {
      var player = _playerProvider.Instance;

      if (player != null)
      {
        foreach (IProgressReader progressReader in player.GetComponentsInChildren<IProgressReader>())
          _saveLoadService.ProgressReaders.Remove(progressReader);
      }

      _playerProvider.Instance = null;

      Object.Destroy(player.gameObject);
    }

    private Vector3 SpawnPosition()
    {
      // return _progressService.ProjectProgress.PlayerPosition == Vector3.zero
      //   ? _mapProvider.Map.PlayerSpawnMarker.transform.position
      //   : _progressService.ProjectProgress.PlayerPosition;

      return _mapProvider.Map.PlayerSpawnMarker.transform.position;
    }
  }
}