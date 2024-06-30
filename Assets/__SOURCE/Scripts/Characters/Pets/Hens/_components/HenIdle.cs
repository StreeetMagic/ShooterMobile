using Characters.Pets.Hens.MeshModels;
using UnityEngine;
using Zenject;

namespace Characters.Pets.Hens._components
{
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
}