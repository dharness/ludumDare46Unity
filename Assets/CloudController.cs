using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Grow()
    {
        this.transform.localScale = this.transform.localScale + new Vector3(0.1f,0.1f,0.1f);
        var pos = this.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y + 0.1f, pos.z);
    }
}
