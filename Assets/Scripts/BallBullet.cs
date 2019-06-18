using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : MonoBehaviour
{
    public float bulletDamage = 10.0f;

    float destroyDelay = 10;
    float collidedDestroyDelay = 2;

    bool workingBullet = true;
    Collider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(workingBullet == true)
        {
            Destroy(gameObject, destroyDelay);
        }
        else
        {
            Destroy(gameObject, collidedDestroyDelay);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(workingBullet == true)
        {
            if(collision.gameObject.tag == "Props")
            {
                collision.gameObject.GetComponent<Destroyable>().takeDamage(bulletDamage);
            }
            workingBullet = false;
            m_Collider.enabled = false;
        }

        
    }

}
