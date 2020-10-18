using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowP : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 followPosition;

    public float clampAngle = 80.0f;

    public float inputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;

    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;

    public float mouseX;
    public float mouseY;

    public float finalInputX;
    public float finalInputZ;

    public float smoothX;
    public float smoothY;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    [SerializeField]
    [Range(-100f, 100f)] public float tordu;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        tordu = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //set up rotation of the sticks here
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, tordu);
   
        transform.rotation = localRotation;


    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        //set the target to follow
        Transform target = CameraFollowObj.transform;
        // move tower the game object that is the target
        float step = CameraMoveSpeed * Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, target.position, 0.06f);
        transform.position = Vector3.MoveTowards(transform.position, target.position,step);
           
    }
}
