using UnityEngine;

namespace LevelDesign
{
  public class DisableMeshRendererOnAwake : MonoBehaviour
  {
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake() =>
      _meshRenderer.enabled = false;
  }
}