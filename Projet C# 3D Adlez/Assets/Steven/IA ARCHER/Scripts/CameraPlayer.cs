using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{


    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;


    public float speedH = 10.0f;
    public float speedV = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }



    void CameraRotation()
     {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseX;

        yRotation -= mouseY;



        transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        Debug.Log("transform local rotation" + transform.localRotation);
    }
}
