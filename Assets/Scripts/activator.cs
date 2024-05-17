using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    // Unity Event, который срабатывает при старте
    public UnityEvent onStart;

    // Start is called before the first frame update
    void Start()
    {
        // Вызываем событие при старте
        if (onStart != null)
        {
            onStart.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
