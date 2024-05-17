// using UnityEngine;
// using UnityEngine.Events;

// public class AutoMover : MonoBehaviour
// {
//     // Публичные переменные для настройки скорости и времени движения
//     public float speed = 5f;
//     public float moveTime = 2f;

//     // Вектор направления движения
//     public Vector3 direction = Vector3.forward;

//     // Unity Event, который срабатывает, когда движение завершено
//     public UnityEvent onMovementComplete;

//     // Внутренние переменные для управления движением
//     private float moveTimer;
//     private bool isMoving;

//     void Update()
//     {
//         // Если объект движется, обновляем его позицию
//         if (isMoving)
//         {
//             transform.Translate(direction * speed * Time.deltaTime);
//             moveTimer -= Time.deltaTime;

//             // Останавливаем движение, когда время истекает
//             if (moveTimer <= 0f)
//             {
//                 isMoving = false;
//                 OnMovementComplete();
//             }
//         }
//     }

//     // Метод для начала движения
//     public void StartMoving()
//     {
//         moveTimer = moveTime;
//         isMoving = true;
//     }

//     // Метод для остановки движения
//     public void StopMoving()
//     {
//         isMoving = false;
//     }

//     // Метод, вызываемый при завершении движения
//     private void OnMovementComplete()
//     {
//         if (onMovementComplete != null)
//         {
//             onMovementComplete.Invoke();
//         }
//     }
// }


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
}