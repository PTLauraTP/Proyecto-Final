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
       
        yield return new WaitForSeconds(tiempoParaCaer);

        miCuerpo.isKinematic = false;
        miCuerpo.mass =30;
        miCuerpo.useGravity = true;
        yield return new WaitForSeconds(tiempoParaDestruirse);
        Destroy(gameObject);
    }
}