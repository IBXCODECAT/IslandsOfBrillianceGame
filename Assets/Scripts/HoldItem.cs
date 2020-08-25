using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    public KeyCode interact;
    public Transform player;
    public Vector3 offset;
    public GameObject objHold;
    public LayerMask pickupable;

    [SerializeField]
    private float distance;

    void Update()
    {
        if (Input.GetKeyDown(interact))
        {
            RaycastHit hit;

            if (Physics.Raycast(player.position + offset, transform.forward, out hit, distance))
            {
                hit.transform.GetComponent<Interactables>();
                hit.transform.SetParent(objHold.transform, false);
            }
        }
    }
}
