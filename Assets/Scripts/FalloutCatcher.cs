using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float spwnHeight = 75;
    //public bool onPlayer;

    public ThrowError showError;

    //private void Update()
    //{
    //    if(onPlayer && transform.position.y <= -30)
    //    {
    //        GameManager.instance.RespawnPlayer();
    //    }
    //}

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("fell to far reset");
            // PlayerController.instance.enabled = false; //
            GameManager.instance.RespawnPlayer();
            // PlayerController.instance.enabled = true; //
        }
    }
}
