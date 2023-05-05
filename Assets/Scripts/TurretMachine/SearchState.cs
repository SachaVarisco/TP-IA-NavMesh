using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SearchState : MonoBehaviour
{
   

    private TurretStateMachine stateMachine;
    private VisionController visionController;
    private float setTime = 2;
    private float currentTime;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = GetComponent<TurretStateMachine>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable(){
        currentTime = setTime;
        Debug.Log("search"); 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (visionController.SeePlayer(out hit)){
            stateMachine.ActivateState(stateMachine.probeState);
            return;
        }
        currentTime -= Time.deltaTime;
        if (currentTime<=0){
            stateMachine.ActivateState(stateMachine.shootState);
        }
    }
}

    
        

