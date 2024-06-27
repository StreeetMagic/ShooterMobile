using UnityEngine;

namespace Gameplay.Portals
{
  public class PortalEditorMeshDisabler : MonoBehaviour
  {
    private void Start()
    {
      gameObject.SetActive(false);
    }
  }
}