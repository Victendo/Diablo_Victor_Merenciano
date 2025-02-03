using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int vidaActual;
    [SerializeField] private int vidaMaxima = 100;
    [SerializeField] private TMP_Text textoVida;

    [SerializeField] private bool youLost;


    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private float distanciaAtaque;
    private NavMeshAgent agent;
    private Camera cam;

    private Transform ultimoClick;

    [SerializeField] private Vector3 NpcPosition;
    [SerializeField] private float tiempoRotacion;

    private PlayerAnimations playerAnimations;

    public PlayerAnimations PlayerAnimations { get => playerAnimations; set => playerAnimations = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        vidaActual = vidaMaxima;
        textoVida.SetText("Vida: " + vidaActual.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movimiento();
        }

        if(ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;

        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            LanzarInteraccion(interactuable);
        }

        }
        else if(ultimoClick && ultimoClick.TryGetComponent(out Enemigo enemigo))
        {

        }

        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
        
    }

    private void LanzarInteraccion(IInteractuable interactuable)
    {
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                agent.SetDestination(hit.point);
                ultimoClick = hit.transform;

                
            }
        }
    }

    public void HacerDanho(float danhoAtaque)
    {
        vidaActual -= 10;
        textoVida.SetText("Vida: " + vidaActual.ToString());
        if (vidaActual <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }

    }
}
