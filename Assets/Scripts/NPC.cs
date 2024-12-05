using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private DialogaSO dialogo;
    [SerializeField] private float tiempoRotacion;
    

    [SerializeField] private Texture2D cursorInteraccion;
    [SerializeField] private Texture2D cursorPorDefecto;
    // Start is called before the first frame update
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, tiempoRotacion, AxisConstraint.Y).OnComplete(()=> SistemaDialogo.sistema.IniciarDialogo(dialogo));
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }



    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
