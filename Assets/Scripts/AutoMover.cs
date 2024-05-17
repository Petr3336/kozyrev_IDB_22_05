using System.Collections;  // Добавляем эту библиотеку
using UnityEngine;
using UnityEngine.Events;

public class AutoMover : MonoBehaviour
{
    // Публичные переменные для настройки скорости, времени движения и задержки
    public float speed = 5f;
    public float moveTime = 2f;
    public float delayTime = 1f; // Новая переменная для задержки

    // Вектор направления движения
    public Vector3 direction = Vector3.forward;

    // Unity Event, который срабатывает, когда движение завершено
    public UnityEvent onMovementComplete;

    // Внутренние переменные для управления движением
    private float moveTimer;
    private bool isMoving;

    void Update()
    {
        // Если объект движется, обновляем его позицию
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            moveTimer -= Time.deltaTime;

            // Останавливаем движение, когда время истекает
            if (moveTimer <= 0f)
            {
                isMoving = false;
                OnMovementComplete();
            }
        }
    }

    // Метод для начала движения с задержкой
    public void StartMoving()
    {
        StartCoroutine(StartMovingWithDelay());
    }

    // Метод для остановки движения
    public void StopMoving()
    {
        isMoving = false;
        StopAllCoroutines(); // Останавливаем все корутины при остановке движения
    }

    // Метод, вызываемый при завершении движения
    private void OnMovementComplete()
    {
        if (onMovementComplete != null)
        {
            onMovementComplete.Invoke();
        }
    }

    // Корутину для запуска движения с задержкой
    private IEnumerator StartMovingWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        moveTimer = moveTime;
        isMoving = true;
    }
}*/

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




