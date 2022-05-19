using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPortable : MonoBehaviour
{
    [SerializeField] private float mouseZoomSpeed = 22.0f;
    [SerializeField] private float touchZoomSpeed = 0.2f;
    [SerializeField] private float zoomMin = 20f;
    [SerializeField] private float zoomMax = 80f;
    private Camera cam;

    // Use this for initialization
    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            // Check if we're on a touch-screen device / Pinch to zoom
            if (Input.touchCount == 2)
            {
                MobileZoom();
            }
        }
        //otherwise use scrollwheel to zoom in / out
        else
        {
            DesktopZoom();
        }
        if (cam.fieldOfView < zoomMin)
        {
            cam.fieldOfView = zoomMin;
        }
        else
        if (cam.fieldOfView > zoomMax)
        {
            cam.fieldOfView = zoomMax;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        cam.fieldOfView += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, zoomMin, zoomMax);
    }
    void MobileZoom()
    {
        // get current touch positions
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);
        // get touch position from the previous frame
        Vector2 touchZeroStarting = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOneStarting = touchOne.position - touchOne.deltaPosition;

        float startingTouchDistance = Vector2.Distance(touchZeroStarting, touchOneStarting);
        float currentTouchDistance = Vector2.Distance(touchZero.position, touchOne.position);

        // get offset value
        float deltaDistance = startingTouchDistance - currentTouchDistance;
        Zoom(deltaDistance, touchZoomSpeed);
    }
    void DesktopZoom()
    {
        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        Zoom(scroll, mouseZoomSpeed);
    }
}