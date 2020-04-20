using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudPickupController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public CloudItemHolder cloudItemHolder;

    public Material highlightMateral;
    Material _selectionDefaultMaterial;
    Transform _selection;

    // Update is called once per frame
    void Update()
    {
        ManageSelections();
        if (Input.GetMouseButtonDown(0))
        {
            if(_selection != null)
            {
                inventoryManager.AddItem(_selection.transform);
                cloudItemHolder.AddItem(_selection.gameObject);
                // Destroy(_selection.gameObject);
                _selection = null;
            }
        }
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
        // Does the ray intersect any objects excluding the player layer
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
