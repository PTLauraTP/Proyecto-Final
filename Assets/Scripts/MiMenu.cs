using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiMenu : MonoBehaviour
{
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("Bloqueo");
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
    //public void IrMenu()
    //{
    //    SceneManager.LoadScene("Menu UI");
    //}
}
