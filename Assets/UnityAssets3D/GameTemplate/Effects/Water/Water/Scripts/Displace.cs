using UnityEngine;

namespace UnityAssets3D.GameTemplate.Effects.Water.Water.Scripts
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(WaterBase))]
    public class Displace : MonoBehaviour
    {
        public void Awake()
        {
            if (enabled)
            {
                OnEnable();
            }
            else
            {
                OnDisable();
            }
        }


        public void OnEnable()
        {
            Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
            Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
        }


        public void OnDisable()
        {
            Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
            Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
        }
    }
}