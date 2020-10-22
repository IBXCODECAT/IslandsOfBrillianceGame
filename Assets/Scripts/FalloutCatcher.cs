using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float spwnHeight = 75;

    private void Update()
    {
        Debug.Log("My Position: " + transform.position.y);

        if (transform.position.y < -50)
        {
            Debug.Log("fell to far reset");
            PlayerController.instance.enabled = false;
            GameManager.instance.RespawnPlayer();
            PlayerController.instance.enabled = true;
        }
    }
}
