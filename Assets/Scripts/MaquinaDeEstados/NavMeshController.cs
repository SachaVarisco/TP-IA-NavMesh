using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [HideInInspector]
    public Transform objective;
    private NavMeshAgent NMA;

    // Start is called before the first frame update
    void Awake()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    public void UpdateDestinyNavToObjective(){
        UpdateDestinyNavMeshAgent(objective.position);
    }

    // Update is called once per frame
    public void UpdateDestinyNavMeshAgent(Vector3 pointDestiny)
    {
        NMA.destination = pointDestiny;
        NMA.Resume();
    }
    //Metodo para que el enemigo se quede quieto
    public void StopNavMeshAgent(){
        NMA.Stop();
    }

    public bool Arrived(){
        return NMA.remainingDistance <= NMA.stoppingDistance && !NMA.pathPending;
    }
}
