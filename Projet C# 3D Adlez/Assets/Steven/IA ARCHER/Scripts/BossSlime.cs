using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : Enemy
{
    public GameObject attractedTo;
    GameObject[] slimes;
    public float strengthOfAttraction = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        SetHpMax(5000);
        SetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        dead();

        Damaged();

        FollowPlayer();

        Attack();

        Fusion();
    }


    void Fusion()
    {
        if(currentHp< maxHp / 10)
        {
            Attract();
        }
    }

    void Attract()
    {
        slimes = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 direction = attractedTo.transform.position;
        foreach (GameObject slime in slimes)
        {
            // direction  = attractedTo.transform.position - transform.position;
            //   slime.GetComponent<Rigidbody>().AddForce(gameObject.transform.position - transform.position * strengthOfAttraction);
            slime.transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position,1000f);

        }

        
        //rb.AddForce(strengthOfAttraction * direction);
    }
}
