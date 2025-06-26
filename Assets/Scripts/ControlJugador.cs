using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            this.GetComponent<ThirdPersonController>().enabled = true;
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
    }
}
