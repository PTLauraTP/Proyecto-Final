using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    [SerializeField] Transform puntoDeInicio;

    [SerializeField] float tiempoInicial;
    [SerializeField] TextMeshProUGUI textoContador;

    [SerializeField] GameObject pantallaGanaste;
    [SerializeField] GameObject pantallaPerdiste;
    [SerializeField] GameObject botonPausa;
    public static GameManager instance;
    [SerializeField] bool retorno = false;

    void Awake() { instance = this; }

    private float tiempoRestante;
    public bool juegoActivo = false;

    private float segundos;
    private float minutos;

    void Start()
    {
        tiempoRestante = tiempoInicial;
        if (tiempoRestante >= 60)
        {
            minutos = tiempoRestante/60;
            Debug.Log(minutos);
            segundos = tiempoRestante % 60;
            Debug.Log(segundos);
            actualizarTemporizador();
        }

        botonPausa.SetActive(true);
        pantallaGanaste.SetActive(false);
        pantallaPerdiste.SetActive(false);

        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            jugador.transform.position = puntoDeInicio.position;
            cc.enabled = true;
        }
    }
    void actualizarTemporizador()
    {
        
        if(segundos < 0)
        {
            segundos = 59;
            minutos--;
        }
        string ceroTexto = segundos <= 9.5f ? "0" : null;
        string tiempoNuevo = minutos.ToString("F0") + ":" + ceroTexto +segundos.ToString("F0");
        textoContador.text = tiempoNuevo;
    }
    public void activarLogica()
    {
        juegoActivo = true;
    }
    void Update()
    {
        if (juegoActivo==false)
        return;
        
        actualizarTemporizador();
        segundos -= Time.deltaTime;


        if (segundos<=0 && minutos <=0)
        {
            segundos = 0; 
            PerderJuego();
        }
    }
    public void CambiarModoJuego()
    {
        retorno = true;
        jugador.transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        jugador.GetComponent<ThirdPersonController>().modificarControlX();
       
    }
    public void setRegeneracion(Transform nuevoGuardado)
    {
        puntoDeInicio = nuevoGuardado;
    }
    public void RespawnJugador()
    {
        
        if (!juegoActivo) return;



        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false; 
            jugador.transform.position = puntoDeInicio.position; 
            cc.enabled = true; 
        }
        else
        {
            jugador.transform.position = puntoDeInicio.position;
        }
    }

    public void GanarJuego()
    {
        if (juegoActivo)
        {
            StartCoroutine(nameof(esperaCelebrar));
            Debug.Log("¡GANASTE!");
            juegoActivo = false;
            pantallaGanaste.SetActive(true);
            botonPausa.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    IEnumerator esperaCelebrar()
    {
        yield return new WaitForSeconds(2);
    }

    public void PerderJuego()
    {
        if (juegoActivo)
        {
            Debug.Log("¡PERDISTE!");
            juegoActivo = false;
            pantallaPerdiste.SetActive(true);
            botonPausa.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
