using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Feu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().currentHp -= 10;
            collision.gameObject.GetComponent<Enemy>().isDamaged = true;

        }
        
        Rigidbody instance;
        instance = Instantiate(Feu, transform.position, transform.rotation) as Rigidbody;
        Destroy(gameObject);
    }
}
