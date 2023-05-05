using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public MonoBehaviour patrollState;
    public MonoBehaviour chaseState;
    public MonoBehaviour alertState;
    public MonoBehaviour startState;
    public MeshRenderer meshRenIndicate;

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
