using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float health = 50.0f;

    private float objectHealth;

    // Start is called before the first frame update
    void Start()
    {
        objectHealth = health;
    }

    public void takeDamage(float amount)
    {
        objectHealth -= amount;

        Debug.Log(gameObject.name + " health: " + health + "/" + objectHealth);

        if(objectHealth < 1)
        {
            Destroy(gameObject);
        }

    }

}
