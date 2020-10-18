using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Archer : Enemy
{
    public Rigidbody Fleche;
    public Transform origine;
    public int force = 1000;
    public Transform cible;
    // Start is called before the first frame update
    void Start()
    {
        SetHpMax(1000);
        SetInstance();
        InvokeRepeating("ArrowInstance", 0.5f, 0.5f);
      //  InvokeRepeating("RandomMove", 1.0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        dead();

        Damaged();    
    }

    void ArrowInstance()
    {
        Rigidbody instance;
        instance = Instantiate(Fleche, origine.position, origine.rotation) as Rigidbody;

  
    }

    //void RandomMove()
    //{

    //    agent.SetDestination(RandomNavmeshLocation(15f));



    //}

    //public Vector3 RandomNavmeshLocation(float radius)
    //{
    //    Vector3 randomDirection = Random.insideUnitSphere * radius;
    //    randomDirection += transform.position;
    //    NavMeshHit hit;
    //    Vector3 finalPosition = Vector3.zero;
    //    if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
    //    {
    //        finalPosition = hit.position;
    //    }
    //    return finalPosition;
    //}


}
