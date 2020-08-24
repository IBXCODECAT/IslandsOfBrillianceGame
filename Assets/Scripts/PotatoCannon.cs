using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCannon : MonoBehaviour
{

    public GameObject potatoAlpha;
    public Transform potatoPosition;
    public float potatoFire;

    public bool cannonFire;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !cannonFire)
        {
            cannonFire = true;
            StartCoroutine(CannonFire());
        }

        IEnumerator CannonFire() 
        {
            GameObject newpotatoAlpha =
                Instantiate(potatoAlpha,
                potatoPosition.position,
                potatoPosition.rotation);
            yield return new
                WaitForSeconds(potatoFire);
            cannonFire = false;
        }

    }






}
