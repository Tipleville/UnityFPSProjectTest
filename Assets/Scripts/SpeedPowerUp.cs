using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    GameObject usedPowerUp;

    public float MovementMultiplier = 2.0f;
    public float EffectLastingInSeconds = 20.0f;

    private void Start()
    {
        usedPowerUp = gameObject.transform.Find("UsedPowerUp").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine( UseSpeedPowerUp(other) );
        }

        //Renderer[] rs; 
        //for(int i = 0; i < 4; i++)
        //    SomeObject.transform.parent.GetChild(SomeObject.transform.GetSiblingIndex() + 1);


    }

    float currCountdownValue;
    IEnumerator UseSpeedPowerUp(Collider player)
    {
        currCountdownValue = EffectLastingInSeconds;

        player.GetComponent<PlayerMove>().alteredSpeed = player.GetComponent<PlayerMove>().defaultSpeed * MovementMultiplier;
        while (currCountdownValue > 0)
        {
            Debug.Log("Speed Effect: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        player.GetComponent<PlayerMove>().alteredSpeed = player.GetComponent<PlayerMove>().defaultSpeed;
    }

}
