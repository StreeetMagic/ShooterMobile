using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.DebugWindows
{
  public class DeleteSavesButton : MonoBehaviour
  {
    public Button Button;

    private void Start()
    {
      Button.onClick.AddListener(DeleteSaves);
    }

    private void DeleteSaves()
    {
      PlayerPrefs.DeleteAll();
    }
  }
}