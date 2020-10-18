using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public int force = 10;
    public GameObject cible;
    Rigidbody rb;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        cible = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        lastPosition = cible.transform.position; // On récupère la dernière position du joueur avant qu'il se fasse tirer dessus
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f);
        ArrowMove();




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Player>().currentHp -= 5;
            //collision.gameObject.GetComponent<Player>().isDamaged = true;
        }
        Destroy(gameObject);
    }

    void ArrowMove()
    {
        // On rajoute un new Vector3 afin de viser un peu plus haut la cible car la position ciblé se trouve sur les pieds et donc la flèche touche généralement le sol avant
        transform.localPosition = Vector3.MoveTowards(transform.localPosition + new Vector3(0, 0.01f, 0) , lastPosition , 0.1f);

     //   transform.localPosition = Vector3.MoveTowards(transform.localPosition, cible.transform.position, 0.1f); // tête chercheuse, esquive impossible sauf si la balle rencontre un obstacle
    }

}
