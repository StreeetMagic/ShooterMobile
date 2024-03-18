using Cinemachine;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Factories;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Cameras
{
  public class CameraFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _factory;
    private readonly PlayerProvider _playerFactory;
    private readonly CameraProvider _cameraProvider;

    public CameraFactory(IZenjectFactory factory, IAssetProvider assetProvider, PlayerProvider playerFactory, CameraProvider cameraProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerFactory = playerFactory;
      _cameraProvider = cameraProvider;
    }

    public void Create(Transform parent)
    {
      Player player = _playerFactory.Player;

      CreateBotCamera(parent, player);
      CreateTopCamera(parent, player);
    }

    private void CreateBotCamera(Transform parent, Player player)
    {
      var prefab = _assetProvider.Get<TopDownCamera>("BotCamera");
      TopDownCamera camera = _factory.Instantiate(prefab, parent);
      _cameraProvider.BotCamera = camera;
      camera.transform.SetParent(null);

      var cmCam = camera.GetComponent<CinemachineVirtualCamera>();
      cmCam.Priority = 11;

      cmCam.Follow = player.transform;
      cmCam.LookAt = player.transform;
    }

    private void CreateTopCamera(Transform parent, Player player)
    {
      var prefab = _assetProvider.Get<TopDownCamera>("TopCamera");
      TopDownCamera camera = _factory.Instantiate(prefab, parent);
      _cameraProvider.TopCamera = camera;
      camera.transform.SetParent(null);

      var cmCam = camera.GetComponent<CinemachineVirtualCamera>();
      cmCam.Priority = 10;

      cmCam.Follow = player.transform;
      cmCam.LookAt = player.transform;
    }
  }
}