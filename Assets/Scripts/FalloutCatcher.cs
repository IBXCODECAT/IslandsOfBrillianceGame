using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float maxFall = -25;
    public float spwnHeight = 75;
    private PlayerController PlyrCtrlDisable;

    public ThrowError showError;

    // Update is called once per frame
    private void Start()
    {
        PlyrCtrlDisable = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (transform.position.y < maxFall)
        {
            showError.Error(3, "Player's elevation is " + transform.position.y + ". The player's elevation should be clamped to " + maxFall);

            PlyrCtrlDisable.enabled = false;
            transform.position = new Vector3(0, spwnHeight, 0);
            PlyrCtrlDisable.enabled = true;
        } 
    }
}
