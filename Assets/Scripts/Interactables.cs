using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Vector3 specRot;
    public Vector3 specScale;

    protected Quaternion originalRot;
    protected Vector3 originalScale;

    public virtual void interact()
    {
        originalRot = transform.rotation;
        originalScale = transform.localScale;
    }
}
