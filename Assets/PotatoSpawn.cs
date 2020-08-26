using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoSpawn : MonoBehaviour
{
    public GameObject PotatoAlpha;

    private void OnEnable()
    {
           Destroy(PotatoAlpha, 10);
    }
    //DestroyObjectDelayed()
      

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
