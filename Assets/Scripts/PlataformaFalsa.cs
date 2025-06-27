using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalsa : MonoBehaviour
{
   [SerializeField] float tiempoParaCaer;
    [SerializeField] float tiempoParaDestruirse;
    private Rigidbody miCuerpo;
    private bool haSidoActivada = false;

    void Awake()
    {
        miCuerpo= GetComponent<Rigidbody>();
        miCuerpo.isKinematic = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (!haSidoActivada && other.gameObject.CompareTag("Player"))
        {
            haSidoActivada = true;
            
           
            StartCoroutine(IniciarCaida());
        }
    }

    private IEnumerator IniciarCaida()
    {
        Debug.Log("hola");
        yield return new WaitForSeconds(tiempoParaCaer);

        miCuerpo.isKinematic = false;
        
        yield return new WaitForSeconds(tiempoParaDestruirse);
        Destroy(gameObject);
    }
}