using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Camera cam;

    private float panSpeed = 25f;


    void Start()
    {
        cam = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        if (GameManager.isGameEnded)
        {
            return;
        }
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            cam.transform.Translate(new Vector3(horizontalInput, verticalInput, 0.0f));

            if (Input.GetMouseButton(0) || Input.touchCount == 1) //
            {
                var newPosition = new Vector3();
                newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
                newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
                // translates to the opposite direction of mouse position.
                transform.Translate(-newPosition);
            }
        
    }


}
