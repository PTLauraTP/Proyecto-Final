using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeVictoria : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CambiarModoJuego();
        }
    }
}
