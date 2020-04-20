using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudItemHolder : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var item = this.items[0];
            items.RemoveAt(0);
            DropItem(item);
        }
    }

    public void AddItem(GameObject item)
    {
        this.items.Add(item);
        item.transform.position = this.transform.position;
        item.transform.parent = this.transform;
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void DropItem(GameObject item)
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
    }
}
