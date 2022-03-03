using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patient_look_around : MonoBehaviour
{

    [SerializeField] Transform main_camera;
    [SerializeField] float sensitivity;
    float headRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;

        transform.Rotate(0f, x, 0f);
        headRotation += y;
        
        if(headRotation > 90.0f) {
            headRotation = 90.0f;
        }
        else if(headRotation < -90.0f){
            headRotation = -90.0f;
        }
        
        main_camera.localEulerAngles = new Vector3(headRotation, 0f, 0f);
    }
}
