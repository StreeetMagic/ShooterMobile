using UnityEngine;

namespace Maps.Markers
{
  public class DisableMeshRendererOnAwake : MonoBehaviour
  {
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake() =>
      _meshRenderer.enabled = false;
  }
}