using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text textoDialogo;

    private bool escribiendo;
    private int indiceFraseActual;


    public static SistemaDialogo sistema;

    private void Awake()
    {
        if (sistema == null)
        {
            sistema = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogaSO dialogo)
    {
        marcoDialogo.SetActive(true);
    }

    private void EscribirFrase()
    {
        
    }

    private void SiguienteFrase()
    {

    }

    private void TerminarDialogo()
    {
        marcoDialogo.SetActive(false);
    }


}
