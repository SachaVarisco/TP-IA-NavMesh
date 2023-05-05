using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProbeState : MonoBehaviour
{

    public float spinSpeed = 120f;
    

    private TurretStateMachine stateMachine;
    private VisionController visionController;
    
   
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<TurretStateMachine>();
        visionController = GetComponent<VisionController>();
    }
    void OnEnable(){ 
        Debug.Log("probe"); 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(visionController.SeePlayer(out hit, true)){
            stateMachine.ActivateState(stateMachine.searchState);
            return;
        }
        transform.Rotate(0f,0f,spinSpeed*Time.deltaTime);
    }
   
}
