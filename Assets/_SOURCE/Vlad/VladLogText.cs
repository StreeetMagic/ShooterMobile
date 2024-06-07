using TMPro;
using UnityEngine;

namespace Vlad
{
  public class VladLogText : MonoBehaviour
  {
    public TextMeshProUGUI Text;

    public static VladLogText Instance { get; private set; }

    private void Awake()
    {
      if (Instance != null)
      {
        Destroy(gameObject);
        return;
      }

      Instance = this;
    }
  }
}