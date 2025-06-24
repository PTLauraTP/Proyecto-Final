using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeMuerte : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RespawnJugador();
        }
    }
}
