using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerStandsOnSamePosition : MonoBehaviour
  {
    [Inject] private PlayerMover _playerMover;

    private Vector3 _lastPosition;

    public float TimeOnSamePosition { get; private set; }

    private void OnEnable()
    {
      _lastPosition = transform.position;
      TimeOnSamePosition = 0;
    }

    private void Update()
    {
      if (transform.position == _lastPosition)
        TimeOnSamePosition += Time.deltaTime;
      else
        TimeOnSamePosition = 0;

      _lastPosition = transform.position;
    }
  }
}