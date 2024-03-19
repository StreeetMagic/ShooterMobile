using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLootSlot : MonoBehaviour
{
  public Image Image;
  public TextMeshProUGUI Text;

  public void Init(Sprite sprite, int itemValue)
  {
    Image.sprite = sprite;
    Text.text = itemValue.ToString();

    Debug.Log("Переписывай давай");
  }
}