using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject followTarget;
    public Vector3 displacement;

    [SerializeField] private int closestZoom = 1;
    [SerializeField] private int farthestZoom = 10;
    private Camera cam;
    
	void Start () {
        cam = GetComponent<Camera>();
        displacement = cam.transform.position - followTarget.transform.position;
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
    }
}
