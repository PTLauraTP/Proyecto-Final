using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    [SerializeField] Transform puntoDeInicio;

    [SerializeField] float tiempoInicial;
    [SerializeField] TextMeshProUGUI textoContador;

    [SerializeField] GameObject pantallaGanaste;
    [SerializeField] GameObject pantallaPerdiste;
    public static GameManager instance;

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

        //textoContador.text = "Tiempo: " + tiempoRestante.ToString("F0"); //numero sin decimales

        if (segundos<=0 && minutos <=0)
        {
            segundos = 0; // Para que no muestre números negativos
            PerderJuego();
        }
    }
    public void setRegeneracion(Transform nuevoGuardado)
    {
        puntoDeInicio = nuevoGuardado;
    }
    public void RespawnJugador()
    {
        //juego terminado no hacer nada
        if (!juegoActivo) return;

        Debug.Log("Jugador ha caído. Reubicando...");

        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false; // desabilita el controlador
            jugador.transform.position = puntoDeInicio.position; // Movemos el transform
            jugador.transform.rotation = puntoDeInicio.rotation; // reseteamos la rotación
            cc.enabled = true; // volvemos a habilitar el contrl
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
            Debug.Log("¡GANASTE!");
            juegoActivo = false;
            pantallaGanaste.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void PerderJuego()
    {
        if (juegoActivo)
        {
            Debug.Log("¡PERDISTE!");
            juegoActivo = false;
            pantallaPerdiste.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
