using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;
    public MeshRenderer meshRenIndicate;
    public Color stateColor = Color.blue;

    public Vector2 sens;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenIndicate.material.color = stateColor;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      Movement();
     // Camera();
    }

    private void Movement()
    {    
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

            rb.velocity = direction * moveSpeed;
        }else{
            rb.velocity = Vector3.zero;
        }
    }


}