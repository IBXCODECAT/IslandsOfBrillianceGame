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
                    hit.transform.localPosition = Vector3.zero;
                    hit.transform.localRotation = Quaternion.Euler(interactables.specRot);
                    hit.transform.localScale = interactables.specScale;
                }
            }
        }
        else if (Input.GetKeyDown(interact) && interactables != null)
        {
            interactables.interact();
        }
    }
}