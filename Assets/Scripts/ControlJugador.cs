using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [SerializeField] ThirdPersonController miControlMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            miControlMovimiento.enabled = true;
            GameManager.instance.activarLogica();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Guardado"))
        {
            Debug.Log("guardado nuevo");
            GameManager.instance.setRegeneracion(collision.transform);
        }
        if (collision.transform.CompareTag("enemigo"))
        {
            GameManager.instance.RespawnJugador();
        }
        if (collision.transform.CompareTag("victoria"))
        {
            GameManager.instance.GanarJuego();
            miControlMovimiento.Celebrar();
        }
    }
}
