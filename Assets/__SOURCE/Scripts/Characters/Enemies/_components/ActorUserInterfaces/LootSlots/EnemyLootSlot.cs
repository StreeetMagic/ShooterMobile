using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Characters.Enemies.ActorUserInterfaces.LootSlots
{
  public class EnemyLootSlot : MonoBehaviour
  {
    public Image Image;
    public TextMeshProUGUI Text;

    public void Init(Sprite sprite, int itemValue)
    {
      Image.sprite = sprite;
      Text.text = itemValue.ToString();
    }
  }
}