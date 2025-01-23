using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private GameObject toggleMision;
    // Start is called before the first frame update
    private void OnEnable()
    {
        eventManager.OnNuevaMision += ActivarToggleMision;
}

    private void ActivarToggleMision()
    {
        toggleMision.SetActive(true);
    }
}
