using Gameplay.Characters.Pets.Hens.MeshModels;
using UnityEngine;
using Zenject;

public class HenIdle : MonoBehaviour
{
  [Inject] private HenAnimator _henAnimator;

  private void Awake()
  {
    enabled = false;
  }

  private void OnEnable()
  {
    _henAnimator.StopMovingAnimation();
  }
}