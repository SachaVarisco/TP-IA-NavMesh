using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    public Color stateColor = Color.yellow;
    public float spinSpeed = 120f;
    public float setTime = 4;
    
    private StateMachine stateMachine;
    private NavMeshController controllerNM;
    private VisionController visionController;
    private float currentTime;
   
    void Awake()
    {
        
        stateMachine = GetComponent<StateMachine>();
        controllerNM = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable(){
        currentTime = setTime;
        stateMachine.meshRenIndicate.material.color = stateColor;
        controllerNM.StopNavMeshAgent();
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
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
        
        currentTime -= Time.deltaTime;
        if(currentTime <= 0){
            stateMachine.ActivateState(stateMachine.patrollState);
            return;
        }
        
    }
        

}
