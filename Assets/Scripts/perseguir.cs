using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class perseguir : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent navMA;
   
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        navMA.updateRotation = false;
        navMA.updateUpAxis = false;
        
    }

    
    void Update()
    {
        navMA.SetDestination(player.transform.position);
    }
}
