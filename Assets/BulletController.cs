using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f,0f,90f);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.CompareTag("Bullet")){
            Destroy(gameObject);
        }
        
    }
}