using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Transform eyes;
    public Transform player;
    public float visionRange = 20f;
    public Vector3 offset = new Vector3(0f,0.3f,0f);

    private NavMeshController controllerNM;

    void Awake(){
        controllerNM = GetComponent<NavMeshController>();
    }
  
    public bool SeePlayer(out RaycastHit hit, bool seePlayer = false){
        Vector3 direction;
        if(seePlayer){
            direction = (player.position + offset) - eyes.position;
        } else
        {
            direction = eyes.forward;
        }
        
        return Physics.Raycast(eyes.position, direction, out hit, visionRange) && hit.collider.CompareTag("Player");
    }
}
