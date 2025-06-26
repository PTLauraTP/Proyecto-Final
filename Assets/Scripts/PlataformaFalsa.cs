using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
    [SerializeField] float tiempoParaCaer;
    [SerializeField] float tiempoParaDestruirse;
    private Rigidbody rb;
    private bool haSidoActivada = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!haSidoActivada && collision.gameObject.CompareTag("Player"))
        {
            haSidoActivada = true;
            Debug.Log("toque la plataforma me caigo wiiii xd");
            StartCoroutine(IniciarCaida());
        }
    }

    private IEnumerator IniciarCaida()
    {
        yield return new WaitForSeconds(tiempoParaCaer);
        rb.isKinematic = false;
        yield return new WaitForSeconds(tiempoParaDestruirse);
        Destroy(gameObject);
    }
}