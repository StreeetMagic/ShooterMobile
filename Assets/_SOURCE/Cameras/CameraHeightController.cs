using Cameras;
using Cinemachine;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;

public class CameraHeightController : MonoBehaviour
{
  private PlayerProvider _playerProvider;
  private CameraProvider _cameraProvider;

  [Inject]
  private void Construct(PlayerProvider playerProvider, CameraProvider cameraProvider)
  {
    _playerProvider = playerProvider;
    _cameraProvider = cameraProvider;
  }

  private void Update()
  {
    if (_playerProvider.PlayerInputHandler == null)
      return;

    if (_playerProvider.PlayerInputHandler.IsMoving)
      RaiseCamera();
    else
      DownCamera();
  }

  private void RaiseCamera()
  {
    _cameraProvider.TopCamera.VirtualCamera.Priority = 11;
    _cameraProvider.BotCamera.VirtualCamera.Priority = 10;
  }

  private void DownCamera()
  {
    _cameraProvider.TopCamera.VirtualCamera.Priority = 10;
    _cameraProvider.BotCamera.VirtualCamera.Priority = 11;
  }
}