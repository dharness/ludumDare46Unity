using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementController : MonoBehaviour
{
    public Camera camera;
    public Rigidbody rb;
    Vector3 movement, forward, right;
    public float moveSpeed = 4;

    void Start()
    {
        forward = camera.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0f, 90f, 0f)) * forward;
    }

    void Update()
    {
        if(Input.anyKey)
        {
            var horz = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");
            var rightMovement = right * horz;
            var upMovement = forward * vert;
            var heading = Vector3.Normalize(rightMovement + upMovement);

            var goingForwardAmount = Vector3.Magnitude(forward - heading); 
            Debug.Log("forward");
            Debug.Log(forward);
            Debug.Log("goingForwardAmount");
            Debug.Log(goingForwardAmount);
            //transform.position = transform.position + (heading * moveSpeed * Time.deltaTime);
            transform.position = transform.position + (heading * (1 + Mathf.Abs(vert)) * moveSpeed * Time.deltaTime);
            Debug.DrawLine(Vector3.zero, forward, Color.red, 2.5f);
            Debug.DrawLine(Vector3.zero, heading, Color.blue, 2.5f);
        }
    }
}
