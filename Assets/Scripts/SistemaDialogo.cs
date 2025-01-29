using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{

    [SerializeField] private GameObject marcoDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Transform npcCamera;
    [SerializeField] private EventManagerSO eventaSO;

    private bool escribiendo;
    private int indiceFraseActual;

    private DialogaSO dialogoActual;


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

    public void IniciarDialogo(DialogaSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0f;

        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
        StartCoroutine(EscribirFrase());
    }

    private IEnumerator EscribirFrase()
    {
        escribiendo = true;

        textoDialogo.text = "";
        char [] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach(char letra in fraseEnLetras)
        {
            textoDialogo.text += letra; 
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }

        escribiendo = false;
    }

    public void SiguienteFrase()
    {
        if(escribiendo)
        {
            CompletarFrase();
        }
        else
        {
            indiceFraseActual++;

            if(indiceFraseActual < dialogoActual.frases.Length)
            {

             StartCoroutine(EscribirFrase());

            }

            else
            {
                TerminarDialogo();
            }
        }
    }

    private void CompletarFrase()
    {
        StopAllCoroutines();
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        escribiendo = false;
    }

    private void TerminarDialogo()
    {
        Time.timeScale = 1f;
        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        
        if(dialogoActual.tieneMision)
        {
            eventaSO.NuevaMision(dialogoActual.mision);
        }

        dialogoActual = null;
        

    }


}
