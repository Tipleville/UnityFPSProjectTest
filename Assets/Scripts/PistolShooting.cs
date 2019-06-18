using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    public float shootForce = 100.0f;
    public GameObject bulletPrefab;
    float shootDelay = 0.5f;

    float damage = 10.0f;
    float range = 100.0f;

    float timeFromLastShot = 0.0f;
    bool hasShot = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if(hasShot == true)
        {
            timeFromLastShot += Time.deltaTime;
            if(timeFromLastShot > shootDelay)
            {
                hasShot = false;
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            hasShot = true;
            timeFromLastShot = 0.0f;
        }
    }
    
    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab) as GameObject;
        projectile.transform.position = transform.position + Camera.main.transform.forward;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = Camera.main.transform.forward * shootForce;
    }
    

}
