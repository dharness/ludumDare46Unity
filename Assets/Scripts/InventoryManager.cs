using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject container;

    public void AddItem(Transform t)
    {
        var go = Instantiate(itemPrefab);
        go.transform.parent = container.transform;
    }
}
