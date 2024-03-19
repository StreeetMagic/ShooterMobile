using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public Image Image;
    
    public void SetIcon(Sprite icon)
    {
        Image.sprite = icon;
    }
}
