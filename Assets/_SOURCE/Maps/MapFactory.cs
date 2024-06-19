using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Portals;
using Infrastructure.Projects;
using Infrastructure.SceneLoaders;
using Scenes._Infrastructure.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maps
{
  public class MapFactory
  {
    private readonly MapProvider _mapProvider;
    private readonly SceneLoader _sceneLoader;
    private readonly ProjectData _projectData;

    public MapFactory(MapProvider mapProvider, SceneLoader sceneLoader, ProjectData projectData)
    {
      _mapProvider = mapProvider;
      _sceneLoader = sceneLoader;
      _projectData = projectData;
    }

    public void Create(Transform parent)
    {
      MoveToRootParent(_mapProvider.Map);
      DisablePortalsToArenas();

      if (_mapProvider.Map.BombSpawner)
        _mapProvider.Map.BombSpawner.SpawnBombs();
    }

    public void Destroy()
    {
      if (_mapProvider.Map == null)
        return;

      Object.Destroy(_mapProvider.Map.gameObject);
      _mapProvider.Map = null;
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);

    private void DisablePortalsToArenas()
    {
      GameLoopSceneTypeId type = _projectData.GetGameLoopSceneTypeId(_sceneLoader.CurrentScene);

      Debug.Log("Текущая сцена: " + type);

      if (type != GameLoopSceneTypeId.Core)
      {
        return;
      }

      List<SceneId> arenas = new();

      foreach (var scene in _sceneLoader.LoadedScenes)
      {
        if (_projectData.GetGameLoopSceneTypeId(scene) == GameLoopSceneTypeId.Arena)
          arenas.Add(scene);
      }

      if (arenas.Count == 0)
      {
        return;
      }

      SceneId lastLoadedArena = arenas.Last();

      Debug.Log(lastLoadedArena + " last arena");

      int count = 0;

      foreach (Portal portal in _mapProvider.Map.Portals)
      {
        if (portal.ToScene == lastLoadedArena)
        {
          portal.Deactivate();
          _mapProvider.Map.PlayerSpawnMarker.transform.position = portal.transform.position;
          count++;
        }
      }

      if (count > 1)
      {
        throw new Exception($"На кор сцене более одного одинакового портала");
      }
    }
  }
}