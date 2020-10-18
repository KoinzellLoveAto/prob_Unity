using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BasicAttaque : MonoBehaviour
{

    /*=======================Spawn============================= */

    public GameObject ballEntity;
    [SerializeField]
    [Range(1f, 30f)] public int range;

    // Start is called before the first frame update
    void Start()
    {
        range = 3;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBall();
    }


    void SpawnBall()
    {
        if (Input.GetButton("Spawn"))
        {

            //Je  récup le vecteur dorectino du perso ( ou il regarde)
            Vector3 dir = transform.TransformDirection(Vector3.forward);

            //Le vecteur position du perso ( ou il est )
            Vector3 pos = transform.position;

            //Je rajotue au cordonnée du perso une constant et je le mutiplie par la direction)
            pos.x += range * dir.x;
            pos.z += range * dir.z;

            //j'intancie une balle, a une certaine pos, puis "Quaternion.identity" j'sais pas j'lai trouver sur
            //la doc
            Instantiate(ballEntity, pos, Quaternion.identity);

            //Debug console qui affiche un message a chaque entité crée
            Debug.Log("hope la");
        }
    }
}
