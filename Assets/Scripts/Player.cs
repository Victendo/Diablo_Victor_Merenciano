using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private float distanciaInteraccion;
    private NavMeshAgent agent;
    private Camera cam;

    private Transform ultimoClick;

    [SerializeField] private Vector3 NpcPosition;
    [SerializeField] private float tiempoRotacion;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
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
        Debug.Log("Me hacen pupa " + danhoAtaque);
    }
}
