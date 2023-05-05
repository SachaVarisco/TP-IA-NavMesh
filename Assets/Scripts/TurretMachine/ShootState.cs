using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootState : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public bool fire;
    
    private TurretStateMachine stateMachine;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<TurretStateMachine>();
    }
    void OnEnable(){
        fire = true;   
    }

    // Update is called once per frame
    void Update()
    {
        while (fire)
        {
            Shoot();
            fire = false;
        };
    
        stateMachine.ActivateState(stateMachine.probeState);
        

    }
  
    void Shoot(){
        Debug.Log("shoot");
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;    
    }
}
