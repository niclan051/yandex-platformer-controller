using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent PlayerEnterEvent = null;
    [SerializeField] private UnityEvent PlayerExitEvent = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerEnterEvent.Invoke();
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerExitEvent.Invoke();
        }
    }
}
