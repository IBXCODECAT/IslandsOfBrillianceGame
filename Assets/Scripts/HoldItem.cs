using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    public KeyCode interact;
    public Transform player;
    public Vector3 offset;
    public GameObject objHold;
    
    private float distance;
    private GameObject target;

    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(player.position + offset, transform.forward, out hit, Mathf.Infinity);

        if (Vector3.Distance(hit.point, player.position) > distance)
        {
            if (hit.transform.gameObject.tag == "PickMeUpBro")
            {
                hit.transform.GetComponent<Interactables>();
                hit.transform.SetParent(objHold.transform, true);
            }
        }
    }
}
