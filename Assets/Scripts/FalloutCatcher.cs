using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float spwnHeight = 75;
    public ThrowError showError;

    private void Update()
    {
        if (transform.position.y < -50)
            GameManager.instance.RespawnPlayer();
    }
}
