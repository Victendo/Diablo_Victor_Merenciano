using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaBlendTree : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private Animator anim;
    
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", agent.velocity.magnitude / agent.speed);
    }
}
