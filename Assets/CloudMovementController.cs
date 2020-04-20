using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementController : MonoBehaviour
{
    public Camera camera;

    Vector3 movement, forward, right;
    float speed = 10;
    Vector2 lastMousePos;
    float lastZ;

    void Start()
    {
        forward = camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * forward;

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lastMousePos = Input.mousePosition;
        lastZ = camera.WorldToScreenPoint(transform.position).z;
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
        if(Input.anyKey || true)
        {
            // var horz = Input.GetAxis("Horizontal");
            // var vert = Input.GetAxis("Vertical");
            Vector2 mouseMovement = GetMouseMovement();
            var horz = mouseMovement.x;
            var vert = mouseMovement.y;

            var rightMovement = right * horz;
            var upMovement = forward * vert;
            var heading = Vector3.Normalize(rightMovement + upMovement);

            // var goingForwardAmount = Vector3.Magnitude(forward - heading);
            // var forwardness = (1 + Mathf.Abs(vert)); 
            // transform.position = transform.position + (heading * speed * Time.deltaTime);
            var z = camera.WorldToScreenPoint(transform.position).z;
            var mousePos = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,z));
            transform.position = new Vector3(mousePos.x, transform.position.y, mousePos.z);

            lastMousePos = mousePos;
        }
    }
}
