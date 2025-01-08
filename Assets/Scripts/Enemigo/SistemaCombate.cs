using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private float velocidadCombate;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private NavMeshAgent agent;
    
    // Start is called before the first frame update

    private void Awake()
    {
        main.Combate = this;

    }

    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(main.MainTarget.position);
    }
}
