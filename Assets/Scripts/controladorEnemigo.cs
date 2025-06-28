using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorEnemigo : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSystem;
    [SerializeField] Collider coliderhijo;
    [SerializeField] AudioSource parlante;
    float esperaRandom;
    // Start is called before the first frame update
    void Start()
    {
        esperaRandom = Random.Range(1, 5);
        coliderhijo.enabled = false;
        StartCoroutine(nameof(ActivarFuego));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ActivarFuego()
    {
        yield return new WaitForSeconds(esperaRandom);
        while (true)
        {
            
            ParticleSystem.Play();
            
            parlante.Play();
            yield return new WaitForSeconds(1f);
            coliderhijo.enabled = true;
            yield return new WaitForSeconds(4f);
            ParticleSystem.Stop();
            yield return new WaitForSeconds(1f);
            coliderhijo.enabled = false;
            yield return new WaitForSeconds(3f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            
            GameManager.instance.RespawnJugador();
        }
    }
}
