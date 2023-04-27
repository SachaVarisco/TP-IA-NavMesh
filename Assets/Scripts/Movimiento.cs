using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;
   
    private bool seeRight = true;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            transform.position += new Vector3(speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, speed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        }
        if(Input.GetAxis("Fire2")!=0 || Input.GetAxis("Fire1")!=0 ){
            if (Input.GetAxisRaw("Fire2") == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
            } else if (Input.GetAxisRaw("Fire2") == -1)
            {
                transform.rotation = Quaternion.Euler(0,0, 180);
            }else if (Input.GetAxisRaw("Fire1") == 1)
            {
                transform.rotation = Quaternion.Euler(0,0, 90);
            }else if(Input.GetAxisRaw("Fire1") == -1){
                transform.rotation = Quaternion.Euler(0,0, 270);
            }
        }
    }



   /* private void Turn(){
        seeRight = !seeRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }*/
}
