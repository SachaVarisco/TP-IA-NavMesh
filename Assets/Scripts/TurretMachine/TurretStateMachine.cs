using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateMachine : MonoBehaviour
{
    public MonoBehaviour probeState;
    public MonoBehaviour searchState;
    public MonoBehaviour shootState;
    public MonoBehaviour startState;
    public MeshRenderer meshRen;

    private MonoBehaviour actualState;
    // Start is called before the first frame update
    private void Start()
    {
        ActivateState(startState);
    }

    // Update is called once per frame 
    private void Update()
    {
        
    }

    public void ActivateState(MonoBehaviour newState){
        if (actualState != null)
        {
            actualState.enabled = false; 
        }
        actualState = newState;
        actualState.enabled = true; 
       
    }
}
