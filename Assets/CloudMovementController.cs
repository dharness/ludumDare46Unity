using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementController : MonoBehaviour
{
    public Camera camera;

    Vector3 movement, forward, right;
    float speed = 10;
    Vector3 lastMousePos;
    float lastZ;

    void Start()
    {
        forward = camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * forward;

        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        var z = camera.WorldToScreenPoint(transform.position).z;
        lastMousePos = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0, z));
    }

    Vector2 GetMouseMovement()
    {
        var sensitivity = 1f;
        float X = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float Y = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        X = Mathf.Clamp(X, -1, 1);
        Y = Mathf.Clamp(Y, -1, 1);
        return new Vector2(X, Y);
    }
        

    void Update()
    {

        Vector2 mouseMovement = GetMouseMovement();
        var horz = mouseMovement.x;
        var vert = mouseMovement.y;

        var rightMovement = right * horz;
        var upMovement = forward * vert;
        var heading = Vector3.Normalize(rightMovement + upMovement);

        var z = camera.WorldToScreenPoint(transform.position).z;
        var mousePos = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,z));

        var lastWorldPos = new Vector3(lastMousePos.x, transform.position.y, lastMousePos.z);
        var currentWorldPos = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        // transform.position = currentWorldPos;
        // transform.position = transform.position + (currentWorldPos - lastWorldPos);
        transform.position = new Vector3(
            transform.position.x + (mousePos.x - lastMousePos.x),
            transform.position.y,
            transform.position.z + (mousePos.z - lastMousePos.z)
        );

        lastMousePos = mousePos;
    }
}
