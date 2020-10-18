using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvement : MonoBehaviour
{
    /*=======================déplacement============================= */
    public static Player_Mouvement instance;
    public GameObject Player;
    //Transform des "point" de caméras, le point fixer sur le perso(follow) & le point qui suit le perso(base)

    public Transform CameraFollow;
    public Transform CameraBase;
    public GameObject _camera; //Object camera principal du joueur

    //Value Input axis Vertical/Horizontal
    float valueH;
    float valueV;

    //Turnspeed on the player when go on a direction
    [SerializeField]
    [Range(0.01f, 100.0f)] public float turnSpeed = 10f;


    //Sensibility of the mouse
    [SerializeField]
    [Range(1f, 200.0f)] public float mouseSensitivity = 20f;


    //Variable déplacement speed
    [SerializeField]
    [Range(1f, 200.0f)] public float speed;

    //Variable déplacement jumpspeed
    [SerializeField]
    [Range(1f, 100.0f)] public float jumpspeed = 8f;

    //Variable gravity
    [SerializeField]
    [Range(1f, 200.0f)] public float gratvity = 20f;

    //Character Component
    CharacterController cc;

    //Deplacement vector player
    Vector3 mouvement = Vector3.zero;





    /*=======================Spawn============================= */

    public GameObject ballEntity;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        speed = 40f;
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {


        SimpleDeplacement();


    }

    private void LateUpdate()
    {
        getRotation();
    }

    void SimpleDeplacement()
    {
        Vector3 forward = _camera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;
        valueH = Input.GetAxis("Horizontal");
        valueV = Input.GetAxis("Vertical");

        Vector3 right = new Vector3(forward.z, 0, -forward.x);

        if (cc.isGrounded)
        {
            mouvement = (valueH * right + valueV * forward) * speed;

            if (Input.GetButton("Jump"))
            {
                mouvement.y = jumpspeed;
            }


        }


        mouvement.y -= gratvity * Time.deltaTime;
        cc.Move(mouvement * Time.deltaTime);
    }

    void getRotation()
    {
        if ((valueV >= 0.2) || (valueV <= -0.2))
        {

            Vector3 relativePos = _camera.transform.TransformDirection(Vector3.forward * valueV);
            relativePos.y = 0.0f;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            Debug.Log("I used getRotation()");
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        }


        if ((valueH >= 0.2) || (valueH <= -0.2))
        {

            Vector3 relativePos = _camera.transform.TransformDirection(Vector3.right * valueH);
            relativePos.y = 0.0f;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        }


    }



}
