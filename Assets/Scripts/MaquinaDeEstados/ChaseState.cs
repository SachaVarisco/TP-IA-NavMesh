using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour
{
    public Color stateColor = Color.red;

    private StateMachine stateMachine;
    private NavMeshController controllerNM;
    private VisionController visionController;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        controllerNM = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }
    void OnEnable(){
        stateMachine.meshRenIndicate.material.color = stateColor;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!visionController.SeePlayer(out hit, true)){
            stateMachine.ActivateState(stateMachine.alertState);
            return;
        }
        controllerNM.UpdateDestinyNavToObjective(); 
    }
}
