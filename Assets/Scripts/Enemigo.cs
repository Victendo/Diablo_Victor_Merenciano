using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    private NavMeshAgent agent;

    List<Vector3> listadoPuntos = new List<Vector3>();
    // Start is called before the first frame update
    private Vector3 destinoActual;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();


        foreach (Transform punto in ruta)
        {
            listadoPuntos.Add(punto.position);
        }

        CalcularDestino();
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        agent.SetDestination(destinoActual);
        yield return null;
    }
    private void CalcularDestino()
    {
        destinoActual = listadoPuntos[0];
    }
}


