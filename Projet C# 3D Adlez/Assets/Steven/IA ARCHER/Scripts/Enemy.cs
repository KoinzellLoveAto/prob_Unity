using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Physics

    public Rigidbody rb;

    public float lookRadius = 10f; // Rayon de la zone de détection
    Transform target;
    protected NavMeshAgent agent;


    // stats

    public int maxHp = 100;
    public int currentHp;
    public HealthBar healthBar;
    private bool isDead = false;
    public bool isDamaged = false;


    protected void SetInstance()
    {
        rb = GetComponent<Rigidbody>();
        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);

        target = Player_Mouvement.instance.Player.transform; // cible des ennemies
        agent = GetComponent<NavMeshAgent>(); // Composant qui permet de reperer la cible selon une zone
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInstance();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Mangetoica(10);
        }

        dead();

        Damaged();

        FollowPlayer();

        Attack();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    // à enlever c'est pour teste les dégats
    protected void Mangetoica(int damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }

    protected void dead()
    {
        if (currentHp <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            Destroy(rb.gameObject);
        }
    }

    protected void FollowPlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }

        }
    }

    protected void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    protected void Damaged()
    {
        if(isDamaged == true)
        {
            healthBar.SetHealth(currentHp);
        }
    }

    protected void Attack()
    {
        rb.velocity = transform.forward;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().currentHp -= 5;
            collision.gameObject.GetComponent<Player>().isDamaged = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    protected void SetHpMax(int hpMax)
    {
        maxHp = hpMax;
    }

}
