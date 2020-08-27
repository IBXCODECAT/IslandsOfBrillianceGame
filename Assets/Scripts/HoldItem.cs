using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{

    public KeyCode interact;
    public KeyCode pickUp;
    public Transform player;
    public Vector3 offset;
    public GameObject objHold;
    public Rigidbody rb;

    private Interactables interactables;

    [SerializeField]
    private float distance;

    void Update()
    {
        if (Input.GetKeyDown(pickUp) && interactables == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(player.position + offset, transform.forward, out hit, distance))
            {

                interactables = hit.transform.gameObject.GetComponent<Interactables>();

                if (interactables)
                {
                    hit.transform.SetParent(objHold.transform, true);
                    rb = hit.transform.GetComponent<Rigidbody>();
                    PhysicsToggle(true);
                    hit.transform.localPosition = Vector3.zero;
                    hit.transform.rotation = Quaternion.Euler(interactables.specRot);
                    hit.transform.localScale = interactables.specScale;
                }
            }
        }
        else if (Input.GetKeyDown(pickUp) && interactables != null)
        {
            interactables.gameObject.transform.rotation = interactables.originalRot;
            interactables.gameObject.transform.localScale = interactables.originalScale;
            interactables.gameObject.transform.SetParent(null);
            PhysicsToggle(false);
            interactables = null;
        }
        
        if (Input.GetKey(interact) && interactables != null)
        {
            interactables.interact();
        }
    }

    void PhysicsToggle(bool freeze)
    {
        if(rb)
        {
            if (freeze)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            else
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
        else
        {
            Debug.LogError("No Rigidbody Found!");
        }    
    }
}