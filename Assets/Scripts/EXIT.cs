using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EXIT : MonoBehaviour
{

    [SerializeField] private UnityEvent Quit = null;
    public void OnApplicationQuit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Quit.Invoke();
        }
    }
}
