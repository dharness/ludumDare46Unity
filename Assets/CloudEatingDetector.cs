using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudEatingDetector : MonoBehaviour
{
    public UnityEvent onCloudDidEat;
    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
        onCloudDidEat?.Invoke();
    }

}
