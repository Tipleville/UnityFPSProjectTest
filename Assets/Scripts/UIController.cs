using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIController : MonoBehaviour
{
    [SerializeField] public GameObject player;

    GameObject currentWeaponInUse;

    GameObject PanelAK47;
    GameObject PanelBitGun;
    GameObject PanelHealth;


    // Start is called before the first frame update
    void Start()
    {
        PanelAK47 = gameObject.transform.Find("PanelAK47").gameObject;
        PanelBitGun = gameObject.transform.Find("PanelBitGun").gameObject;
        PanelHealth = gameObject.transform.Find("PanelHealth").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentWeaponInUse = player.GetComponent<Player>().currentWeapon;
        
        if(currentWeaponInUse.name == "BitGun")
        {
            PanelAK47.SetActive(false);
            PanelBitGun.SetActive(true);
        }
        else if (currentWeaponInUse.name == "AK-47")
        {
            PanelBitGun.SetActive(false);
            PanelAK47.SetActive(true);
            PanelAK47.transform.Find("Utility").transform.Find("Ammunition").GetComponent<Text>().text =
                (currentWeaponInUse.GetComponent<AK47Shooting>().bulletsInMagazine.ToString() + "/" +
                currentWeaponInUse.GetComponent<AK47Shooting>().bulletsInReserve.ToString());
            AlterBullets();
        }

        // Update Player health
        PanelHealth.transform.Find("HealthNumber").GetComponent<Text>().text = player.GetComponent<Player>().playerHealth.ToString();
    }


    // could be more efficient
    void AlterBullets()
    {
        int bulletAmount = (int)currentWeaponInUse.GetComponent<AK47Shooting>().bulletsInMagazine;
        GameObject utility = PanelAK47.transform.Find("Utility").gameObject;

        int bulletIndex = (bulletAmount-4) / 5 + (bulletAmount != 0 ? 1 : 0);

        if (bulletIndex != 6)
        {
            for (int i = 5; i < bulletIndex; i--)
            {
                utility.transform.Find("DT Bullet 6 (" + i.ToString() + ")").gameObject.SetActive(true);
            }
  
            for (int k = 0; k < 6 - bulletIndex; k++)
            {
                utility.transform.Find("DT Bullet 6 (" +  k.ToString() + ")").gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                utility.transform.Find("DT Bullet 6 (" + i.ToString() + ")").gameObject.SetActive(true);
            }
        }
        



    }
}
