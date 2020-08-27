using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCannon : Interactables
{
    public GameObject PotatoAlpha;
    public Transform potatoPosition;
    public float potatoFire;

    public float potatoPower;
    private bool cannonFire;

    public override void interact()
    {
        if (cannonFire == false)
        {
            cannonFire = true;
            StartCoroutine(CannonFire());
        }

    }

    IEnumerator CannonFire()
    {
        GameObject newPotatoAlpha = Instantiate(PotatoAlpha, potatoPosition.position, transform.rotation);
        newPotatoAlpha.GetComponent<Rigidbody>().AddForce(potatoPosition.transform.forward * potatoPower);
        yield return new WaitForSeconds(potatoFire);
        cannonFire = false;
    }
}