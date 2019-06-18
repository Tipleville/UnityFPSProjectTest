using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth = 100.0f;

    Camera playerCamera;
    public GameObject pistolBitGun;
    public GameObject rifleAK_47;

    public Transform rifleTransform;

    [HideInInspector] public GameObject currentWeapon;

    private Transform defaultRifleTransform;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = rifleAK_47;
        playerCamera = gameObject.GetComponentInChildren<Camera>();
        defaultRifleTransform = rifleAK_47.GetComponent<AK47Shooting>().defaultTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("q"))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        
        pistolBitGun.SetActive(!pistolBitGun.activeSelf);

        rifleAK_47.SetActive(!rifleAK_47.activeSelf);
        if(pistolBitGun.activeSelf == true)
        {
            currentWeapon = pistolBitGun;
        }
        else if (rifleAK_47.activeSelf == true)
        {
            currentWeapon = rifleAK_47;
            rifleTransform = defaultRifleTransform;
        }

    }

}
