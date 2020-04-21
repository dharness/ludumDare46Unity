using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudPickupController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public CloudItemHolder cloudItemHolder;
    public CapsuleCollider collider;

    public Material highlightMateral;
    Material _selectionDefaultMaterial;
    Transform _selection;
    Transform flyingItem;
    List<Transform> _grabbables = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        ManageSelections();

        if(_selection != null)
        {
            var selectionRB =  _selection.GetComponent<Rigidbody>();
            if (Input.GetMouseButton(0))
            {
                selectionRB.isKinematic = true;
                selectionRB.MovePosition( _selection.position + new Vector3(0,0.07f,0));
                flyingItem = _selection;
            } else if( flyingItem != null) {
                DropItem(flyingItem);
            }
        }
        else if(flyingItem != null) {
            DropItem(flyingItem);
        }
    }

    void DropItem(Transform item)
    {
        var rb = item.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.freezeRotation = false;
    }

    void ManageSelections()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = _selectionDefaultMaterial;
            _selection = null;
          
        }

        RaycastHit hit;
        int layerMask = 1 << 9;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                _selection = selection;
                _selectionDefaultMaterial = selectionRenderer.material;
                selectionRenderer.material = highlightMateral;
            }
        }
    }
}
