using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public Vector3 specRot;
    public Vector3 specScale;

    [HideInInspector]
    public Quaternion originalRot;
    [HideInInspector]
    public Vector3 originalScale;

    public virtual void interact()
    {
        Debug.LogError("You Have No Function Here!");
    }

    public virtual void OnEnable()
    {
        originalRot = transform.rotation;
        originalScale = transform.localScale;
    }
}
