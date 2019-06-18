using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Shooting : MonoBehaviour
{
    public float maxMagazineSize = 30f;
    public float initialBulletsInReserve = 90f;

    public float damage = 5.0f;
    public float range = 100.0f;

    public float fireRate = 15f;


    public Camera fpsCam;

    [HideInInspector] public Transform defaultTransform;

    [HideInInspector] public float bulletsInMagazine;
    [HideInInspector] public float bulletsInReserve;

    private Animation rifleAnimation;
    private bool reloading = false;
    private float nextTimeToFire = 0f;





    // Start is called before the first frame update
    void Start()
    {
        bulletsInMagazine = maxMagazineSize;
        bulletsInReserve = initialBulletsInReserve;
        rifleAnimation = gameObject.GetComponent<Animation>();
        defaultTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloading == true && rifleAnimation.IsPlaying("AK-47_Reload") == false)
        {
            // The animation has just ended
            while (bulletsInMagazine != 30 && bulletsInReserve != 0)
            {
                bulletsInMagazine++;
                bulletsInReserve--;
            }
            reloading = false;
        }
        else if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else if(Input.GetKeyDown(KeyCode.R) && bulletsInMagazine < 30 && bulletsInReserve > 0)
        {
            Debug.Log("Reloading");
            reloading = true;
            rifleAnimation.Play("AK-47_Reload");
        }

    }

    void Shoot() // this might be used on a laser gun later
    {
        if(bulletsInMagazine > 0)
        {
            bulletsInMagazine--;
            rifleAnimation.Play("Shoot");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
        else
        {
            // play some empty sound effect
        }
    }

}
