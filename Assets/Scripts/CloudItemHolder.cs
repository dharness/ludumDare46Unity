using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudItemHolder : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(this.items.Count > 0)
            {
                var item = this.items[0];
                items.RemoveAt(0);
                DropItem(item);
            }
        }
    }

    public void AddItem(GameObject item)
    {
        this.items.Add(item);
        // item.transform.parent = this.transform;
        item.transform.DOMove(this.transform.position, 1f);
        // item.transform.position = this.transform.position;
        item.GetComponent<Rigidbody>().isKinematic = true;
        
    }

    public void DropItem(GameObject item)
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
    }
}
