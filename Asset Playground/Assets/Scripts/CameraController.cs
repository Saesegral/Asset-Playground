using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject followTarget;
    public Vector3 displacement;

    [SerializeField] private int closestZoom = 1;
    [SerializeField] private int farthestZoom = 10;
    private Camera cam;
    private Vector3 mousePositionOld;

    void Start () {
        cam = GetComponent<Camera>();
        displacement = cam.transform.position - followTarget.transform.position;
        //Sets mouse position to point off the screen, since it needs z=0 to be on the screen. Use this to check if the mouse is on the screen or not.
        mousePositionOld = Vector3.forward;
	}
	
	void Update () {
        cam.transform.position = followTarget.transform.position + displacement;

        if (cam.orthographic) {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && cam.orthographicSize > closestZoom) {
                cam.orthographicSize--;
            } else if (Input.GetAxis("Mouse ScrollWheel") < 0f && cam.orthographicSize < farthestZoom) {
                cam.orthographicSize++;
            }
        }
        
        if (Input.GetMouseButton(1)) {
            if (mousePositionOld.z != 1) {
                //This only rotates in place.
                cam.transform.RotateAround(followTarget.transform.position, Input.mousePosition.x - mousePositionOld.x);
            }
            mousePositionOld = Input.mousePosition;
        }else{
            mousePositionOld = Vector3.forward;
        }
    }
}
