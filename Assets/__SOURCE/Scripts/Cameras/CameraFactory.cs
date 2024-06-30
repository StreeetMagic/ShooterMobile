using Cinemachine;
using Gameplay.Characters.Players;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;

namespace Cameras
{
  public class CameraFactory
  {
    private const string BotCamera = nameof(BotCamera);
    private const string TopCamera = nameof(TopCamera);

    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly PlayerProvider _playerFactory;
    private readonly CameraProvider _cameraProvider;
    private readonly ArtConfigProvider _artConfigProvider;

    public CameraFactory(GameLoopZenjectFactory factory, AssetProvider assetProvider, PlayerProvider playerFactory, CameraProvider cameraProvider, ArtConfigProvider artConfigProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerFactory = playerFactory;
      _cameraProvider = cameraProvider;
      _artConfigProvider = artConfigProvider;
    }

    public void Create(Transform parent)
    {
      var player = _playerFactory.Instance;

      CreateCamera(parent, player.Transform, BotCamera, 11);
      CreateCamera(parent, player.Transform, TopCamera, 10);

      _cameraProvider.MainCamera = Object.FindObjectOfType<Camera>();
    }

    private void CreateCamera(Transform parent, Transform player, string cameraType, int priority)
    {
      PrefabId prefabId = cameraType == BotCamera
        ? PrefabId.BotCamera
        : PrefabId.TopCamera;

      GameObject prefab = _artConfigProvider.GetPrefab(prefabId);

      var camera = _factory.InstantiateGameObject(prefab, parent).GetComponent<TopDownCamera>();

      if (cameraType == BotCamera)
        _cameraProvider.BotCamera = camera;
      else if (cameraType == TopCamera)
        _cameraProvider.TopCamera = camera;

      camera.transform.SetParent(null);

      var cmCam = camera.GetComponent<CinemachineVirtualCamera>();
      cmCam.Priority = priority;
      cmCam.Follow = player;
      cmCam.LookAt = player;
    }
  }
}