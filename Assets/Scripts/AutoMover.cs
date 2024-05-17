
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutoMover : MonoBehaviour
{
    public Vector3 offsetPosition; // Смещение относительно текущей позиции
    public float moveDuration = 1.0f; // Время движения до целевой позиции
    public float delayBeforeMove = 0.5f; // Задержка перед началом движения
    public UnityEvent onMoveComplete; // UnityEvent, активируется по завершению движения

    private Vector3 startPosition; // Начальная позиция объекта
    private Vector3 targetPosition; // Целевая позиция
    private bool movingToTarget = true; // Флаг направления движения
    private Coroutine moveCoroutine;

    private void Start()
    {
        startPosition = transform.position; // Сохранение начальной позиции
        targetPosition = startPosition + offsetPosition; // Вычисление целевой позиции
    }

    public void ActivateMovement()
    {
        // Если объект уже двигается, остановим текущую корутину
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        // Запуск корутины движения с задержкой
        moveCoroutine = StartCoroutine(MoveWithDelay());
    }

    private IEnumerator MoveWithDelay()
    {
        // Ожидание перед началом движения
        yield return new WaitForSeconds(delayBeforeMove);

        // Выбор целевой позиции в зависимости от текущего направления движения
        Vector3 target = movingToTarget ? targetPosition : startPosition;

        // Линейная интерполяция между начальной и конечной позициями
        float elapsedTime = 0;
        Vector3 initialPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, target, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Устанавливаем точную конечную позицию
        transform.position = target;

        // Переключение направления движения
        movingToTarget = !movingToTarget;

        // Активация UnityEvent
        onMoveComplete?.Invoke();
    }
}




