using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollState : MonoBehaviour
{
    public Transform[] wayPoints;
    public Color stateColor = Color.green;

    private StateMachine stateMachine;
    private NavMeshController controllerNM;
    private VisionController visionController;
    private int nextWayPoint;
    // Start is called before the first frame update
    void Awake()
    {
        controllerNM = GetComponent<NavMeshController>();
        stateMachine = GetComponent<StateMachine>();
        visionController = GetComponent<VisionController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(visionController.SeePlayer(out hit)){
            controllerNM.objective = hit.transform;
            stateMachine.ActivateState(stateMachine.chaseState);
            return;
        }
        if (controllerNM.Arrived())
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
            ChangeDestiny();
        }
    }
    void OnEnable()
    {
        stateMachine.meshRenIndicate.material.color = stateColor;
        ChangeDestiny();
    }

    private void ChangeDestiny(){
        controllerNM.UpdateDestinyNavMeshAgent(wayPoints[nextWayPoint].position);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled){
            stateMachine.ActivateState(stateMachine.alertState);
        }
    }
}
