using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float spwnHeight = 75;

    public ThrowError showError;

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("fell to far reset");
            // PlayerController.instance.enabled = false; //
            PlayerController.instance.transform.position = new Vector3(0, spwnHeight, 0);
            showError.Error(2, "Player Y index is out of range");
            // PlayerController.instance.enabled = true; //
        }
    }
}
