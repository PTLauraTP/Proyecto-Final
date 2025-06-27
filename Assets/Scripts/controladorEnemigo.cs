using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorEnemigo : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] Collider coliderhijo;
    // Start is called before the first frame update
    void Start()
    {
        coliderhijo.enabled = false;
        StartCoroutine(nameof(ActivarFuego));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ActivarFuego()
    {
        while (true)
        {
            
            ParticleSystem.Play();
            coliderhijo.enabled = true;
            yield return new WaitForSeconds(4f);
            coliderhijo.enabled = false ;
            ParticleSystem.Stop();
            yield return new WaitForSeconds(3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("toque al player");
            GameManager.instance.RespawnJugador();
        }
    }
}
