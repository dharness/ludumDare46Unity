using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rb.isKinematic = false;
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
