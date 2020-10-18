using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Player_Mouvement _Player;
    public CameraFollowP _CamFollow;
    public float min_distance = 1.0f;
    public float max_distance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    public void Awake()
    {
        //get LookDirection of the camera
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }


    // Start is called before the first frame update
    void Start()
    {
        smooth = 10f;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * max_distance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.01f), min_distance, max_distance);
        }
        else
        {
            distance = max_distance;

        }

       // if (Player_Mouvement.instance.speed) 
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, dollyDir * distance, 0);
    }
}
