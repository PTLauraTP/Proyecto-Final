using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
    [SerializeField] float tiempoParaCaer;
    [SerializeField] float tiempoParaDestruirse;

    private Rigidbody cuerpo;
    private bool haSidoActivada = false;

    void Awake()
    {
        cuerpo = GetComponent<Rigidbody>();
        cuerpo.isKinematic = true;  
        cuerpo.useGravity = false;  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!haSidoActivada && collision.gameObject.CompareTag("Player"))
        {
            haSidoActivada = true;
            Debug.Log("Plataforma activad va a caer");
            StartCoroutine(CaerConRetraso());
        }
    }

    private IEnumerator CaerConRetraso()
    {
        yield return new WaitForSeconds(tiempoParaCaer);
        cuerpo.isKinematic = false;
        cuerpo.useGravity = true;
        yield return new WaitForSeconds(tiempoParaDestruirse);
        Destroy(gameObject);
    }
}