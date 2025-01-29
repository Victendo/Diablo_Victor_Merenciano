using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{

    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private MisionSO misionAsociada;

    private Outline outline;
    [SerializeField] private DialogaSO dialogo1;
    [SerializeField] private DialogaSO dialogo2;
    [SerializeField] private float tiempoRotacion;
    [SerializeField] private Transform cameraPoint;
    

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;

    private DialogaSO dialogoActual;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
        dialogoActual = dialogo1;
    }

    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if(misionTerminada == misionAsociada)
        {
            dialogoActual = dialogo2;
        }
    }

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogo.sistema.IniciarDialogo(dialogoActual, cameraPoint));
    }

   

   

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, new Vector2(0, 0), CursorMode.Auto);
        outline.enabled = true;
    }



    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, new Vector2(0, 0), CursorMode.Auto);
        outline.enabled = false;
    }
}
