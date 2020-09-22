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
    public LayerMask interactableLayer;

    private Interactables interactables;

    [SerializeField]
    private float distance;

    void Update()
    {
        if (Input.GetKeyDown(pickUp) && interactables == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(player.position + offset, transform.forward, out hit, distance, interactableLayer))
            {

                interactables = hit.transform.gameObject.GetComponent<Interactables>();

                if (interactables)
                {
                    interactables.transform.SetParent(objHold.transform, true);
                    rb = interactables.transform.GetComponent<Rigidbody>();
                    PhysicsToggle(true);
                    interactables.transform.localPosition = Vector3.zero;
                    interactables.transform.rotation = Quaternion.Euler(interactables.specRot);
                    interactables.transform.localScale = interactables.specScale;
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