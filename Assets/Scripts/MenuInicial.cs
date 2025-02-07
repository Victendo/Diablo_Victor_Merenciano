using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject menuHistoria;


    public void EntrarJuego()
    {
        SceneManager.LoadScene("JuegoDiablo");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void EntrarOpciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void EntrarHistoria()
    {
        menuInicio.SetActive(false);
        menuHistoria.SetActive(true);
    }

    public void SalirHistoria()
    {
        menuInicio.SetActive(true);
        menuHistoria.SetActive(false);
    }

    public void SalirOpciones()
    {
        menuInicio.SetActive(true);
        menuOpciones.SetActive(false);
    }
}
