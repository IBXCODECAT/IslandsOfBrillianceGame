using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinCollision : MonoBehaviour
{
    bool TimerStarted;
    void OnCollisionEnter(Collision collision)
    {
        if(TimerStarted == false && collision.transform.tag == "Projectile")
        {
            TimerStarted = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
