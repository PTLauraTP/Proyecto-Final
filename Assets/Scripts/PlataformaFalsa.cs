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

    // Este método se llama cuando un objeto con un collider SÓLIDO choca con este.
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el que nos ha tocado es el jugador y si no ha sido activada ya.
        if (!haSidoActivada && collision.gameObject.CompareTag("Player"))
        {
            haSidoActivada = true;
            Debug.Log("¡El jugador ha tocado la plataforma! Iniciando secuencia de caída.");
            // Iniciamos la corutina que hará que todo suceda.
            StartCoroutine(IniciarCaida());
        }
    }

    private IEnumerator IniciarCaida()
    {
        // 1. El jugador se asusta durante este tiempo.
        yield return new WaitForSeconds(tiempoParaCaer);

        // 2. La magia sucede aquí. Desactivamos "isKinematic".
        // Ahora la gravedad y otras fuerzas afectan a la plataforma, y empezará a caer.
        rb.isKinematic = false;

        // 3. Esperamos un poco más antes de destruir el objeto.
        // Esto es para que el jugador pueda ver la plataforma cayendo al vacío.
        yield return new WaitForSeconds(tiempoParaDestruirse);
        Destroy(gameObject);
    }
}