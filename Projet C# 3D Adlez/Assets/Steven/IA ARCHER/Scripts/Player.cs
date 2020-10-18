using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Singleton

    // permet d'instancier le joueur afin de pouvoir le cibler avec l'IA

    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    // Physics

    public CharacterController Cc;
    public GameObject player;
    public Rigidbody rb;
    public Rigidbody attackArea;
    public Transform attackAreaOrigine;

    // mobility

    
    bool canHeMove = true;
    Vector3 moveDir;
    Vector3 moveDirHori;
    public float speed = 10f;
    public float gravity = 10f;


    // stats
        //hp
    public int maxHp = 100;
    public int currentHp;
    public HealthBar healthBar;

        //mp
    public int maxMp = 105;
    public int currentMp;
    public ManaBar manaBar;

    public bool isDamaged = false;
    public bool usedMana = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cc = GetComponent<CharacterController>();

        currentHp = maxHp;
        healthBar.SetMaxHealth(maxHp);

        currentMp = maxMp;
        manaBar.SetMaxMana(maxMp);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Damaged();
        ManaUsed();
        Dead();

        if (Input.GetKeyDown(KeyCode.D))
        {
            Mangetoica(10);
        }

    }


    // à enlever c'est pour teste les dégats
    void Mangetoica(int damage)
    {
        currentHp -= damage;
        healthBar.SetHealth(currentHp);
    }


    void Move()
    {
        // run Augmente la vitesse pour la sensation de courir

        if (Input.GetButton("Run"))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }

        // jump

        if (Input.GetButton("Jump"))
        {
            Cc.Move(new Vector3(0,10f,0) * Time.deltaTime);
        }

        // tp

        if (Input.GetKeyDown(KeyCode.F))
        {
            Cc.Move(Vector3.forward * 1000* Time.deltaTime);
        }



        if (canHeMove) // note la variable canHeMove pourra permettre de le stun si on a besoin
        {
            // Déplacement du personnage que sur le sol
            if (Cc.isGrounded)
            {
                moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;

                moveDirHori = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirHori = transform.TransformDirection(moveDirHori);
                moveDirHori *= speed;
            }
            moveDir.y -= gravity * Time.deltaTime;
            moveDirHori.y -= gravity * Time.deltaTime;

            // rotation du personnage
          //  transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 2 * 10);

            // déplacement avant arrière
            Cc.Move(moveDir * Time.deltaTime);


            // déplacement gauche droite
            Cc.Move(moveDirHori * Time.deltaTime);


        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Rigidbody instance;
        instance = Instantiate(attackArea, attackAreaOrigine.position, transform.rotation) as Rigidbody;
        }


    }

    void Damaged()
    {
        if (isDamaged == true)
        {
            healthBar.SetHealth(currentHp);
        }
    }

    void ManaUsed()
    {
        if (usedMana == true)
        {
            manaBar.SetMana(currentMp);
        }
    }

    void Dead()
    {
        if (currentHp <= 0)
        {
            Destroy(rb.gameObject);
        }
    }
}
