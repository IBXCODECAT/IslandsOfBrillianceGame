using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potatoSpawn : MonoBehaviour
{

    public GameObject PotatoAlpha;
    public float despawn = 1;
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
      

    }


    void DestroyObjectDelayed()
    {
        Destroy(PotatoAlpha, 5);
    }



}
