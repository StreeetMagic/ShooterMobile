using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private float _durationFirstMaterial; // Время, сколько будет первый материал
    [SerializeField] private float _transitionDuration; // Время перехода ко второму материалу
    [SerializeField] private float _durationSecondMaterial; // Время, сколько будет второй материал
    public Material newMaterial; // Материал, на который нужно поменять
    public Material transitionMaterial; // Промежуточный материал
    private List<Material> originalMaterials; // Список исходных материалов
    [SerializeField] private List<SkinnedMeshRenderer> skinnedMeshRenderers; // Список SkinnedMeshRenderer

    void Start()
    {
        // Инициализируем список исходных материалов
        originalMaterials = new List<Material>();

        // Сохраняем исходные материалы
        foreach (var renderer in skinnedMeshRenderers)
        {
            if (renderer != null)
            {
                originalMaterials.Add(renderer.material);
            }
            else
            {
                Debug.LogError("One of the SkinnedMeshRenderers is not set.");
            }
        }
    }

    // Метод для изменения материала на заданное время
    [ContextMenu("ChangeMaterial")]
    [Button]
    public void ChangeMaterial()
    {
        if (newMaterial != null && transitionMaterial != null && skinnedMeshRenderers.Count == originalMaterials.Count)
        {
            // Меняем материалы на новый
            foreach (var renderer in skinnedMeshRenderers)
            {
                renderer.material = newMaterial;
            }

            // Ждем заданное время с новым материалом
            DOVirtual.DelayedCall(_durationFirstMaterial, () =>
            {
                // Плавный переход к transitionMaterial
                foreach (var renderer in skinnedMeshRenderers)
                {
                    Material originalMaterial = originalMaterials[skinnedMeshRenderers.IndexOf(renderer)];
                    renderer.material.DOColor(transitionMaterial.color, _transitionDuration).OnComplete(() =>
                    {
                        // Устанавливаем transitionMaterial
                        renderer.material = transitionMaterial;

                        // Ждем заданное время со вторым материалом
                        DOVirtual.DelayedCall(_durationSecondMaterial, () =>
                        {
                            // Переход обратно к оригинальному материалу
                            renderer.material.DOColor(originalMaterial.color, _transitionDuration).OnComplete(() =>
                            {
                                // Возвращаем оригинальный материал
                                renderer.material = originalMaterial;
                            });
                        });
                    });
                }
            });
        }
        else
        {
            Debug.LogError("SkinnedMeshRenderers, new material, or transition material is not set, or original materials list count does not match renderers list count.");
        }
    }
}
