using DG.Tweening;
using UnityEngine;

public class Base_UI_outline_rotator : MonoBehaviour
{
    public RectTransform uiElement; // ссылка на RectTransform элемента, который вы хотите вращать
    public float rotationSpeed = 1f; // скорость вращения в градусах в секунду

    void Start()
    {
        // Начать бесконечное вращение UI элемента при запуске сцены
        Rotate();
    }

    public void Rotate()
    {
        // Выполнить бесконечное вращение элемента по оси Z с использованием DoTween
        uiElement.DORotate(new Vector3(0f, 0f, 360f), rotationSpeed, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental) // Устанавливаем бесконечное повторение
            .OnUpdate(() => uiElement.localEulerAngles = new Vector3(0f, 0f, uiElement.localEulerAngles.z));
    }
}
