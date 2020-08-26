using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCannon : MonoBehaviour
{
    public GameObject PotatoAlpha;
    public Transform potatoPosition;
    public float potatoFire;

    public float potatoPower;

    public bool cannonFire;



    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && !cannonFire)
        {
            //cannonFire = true;
              GameObject newPotatoAlpha = Instantiate(PotatoAlpha, potatoPosition.position, potatoPosition.rotation);
        newPotatoAlpha.GetComponent<Rigidbody>().AddForce(transform.forward * potatoPower);//StartCoroutine(CannonFire());
        }
    }

    IEnumerator CannonFire()
    {
      
        yield return new WaitForSeconds(potatoFire);
        cannonFire = false; 
    }
}