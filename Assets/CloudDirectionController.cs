using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDirectionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        // Vector3 mouse = Input.mousePosition;
        // Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        var sensitivity = 5f;
        float X = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float Y = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        this.transform.position = new Vector3(
            this.transform.position.x + X,
            this.transform.position.y,
            this.transform.position.z + Y);
        Debug.Log(X + ":" + Y);
    }
}
