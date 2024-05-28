using AssetProviders;
using Cinemachine;
using Gameplay.Characters.Players;
using UnityEngine;
using ZenjectFactories;

namespace Cameras
{
  public class CameraFactory
  {
    private const string BotCamera = nameof(BotCamera);
    private const string TopCamera = nameof(TopCamera);

    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _factory;
    private readonly PlayerProvider _playerFactory;
    private readonly CameraProvider _cameraProvider;

    public CameraFactory(GameLoopZenjectFactory factory, IAssetProvider assetProvider, PlayerProvider playerFactory, CameraProvider cameraProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerFactory = playerFactory;
      _cameraProvider = cameraProvider;
    }

    public void Create(Transform parent)
    {
      Player player = _playerFactory.Player;

      CreateCamera(parent, player, BotCamera, 11);
      CreateCamera(parent, player, TopCamera, 10);

      _cameraProvider.MainCamera = Object.FindObjectOfType<Camera>();
    }

    private void CreateCamera(Transform parent, Player player, string cameraType, int priority)
    {
      var prefab = _assetProvider.Get<TopDownCamera>(cameraType);
      TopDownCamera camera = _factory.InstantiateMono(prefab, parent);

      if (cameraType == BotCamera)
        _cameraProvider.BotCamera = camera;
      else if (cameraType == TopCamera)
        _cameraProvider.TopCamera = camera;

      camera.transform.SetParent(null);

      var cmCam = camera.GetComponent<CinemachineVirtualCamera>();
      cmCam.Priority = priority;

      Transform transform = player.transform;
      cmCam.Follow = transform;
      cmCam.LookAt = transform;
    }
  }
}