using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    private Transform mainTarget;

    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform MainTarget { get => mainTarget;}

    private void Start()
    {
        patrulla.enabled = true;
    }
    public void ActivaCombate(Transform target)
    {
        mainTarget = target;
        combate.enabled = true;
    }
}


