using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magie : MonoBehaviour
{

    public int force = 1000;
    public Rigidbody Boule_de_feu;
    public Rigidbody Onde_de_choc;
    public Transform origine; // pour éviter que la boule de feu sorte et touche le joueur on place un emplacement d'origine devant le joueur pour tirer
    public int bouleDeFeuMana = 5;
    public int OndeDeChocMana = 20;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        bouleDeFeu();
        OndeDeChoc();
    }

    void bouleDeFeu()
    {
        if (Input.GetKeyUp(KeyCode.I) && player.currentMp > 0)
        {
            Rigidbody instance;
            instance = Instantiate(Boule_de_feu, origine.position, origine.rotation) as Rigidbody;
            instance.AddForce(transform.forward * force);
            player.currentMp -= bouleDeFeuMana;
            player.usedMana = true;
        }
    }

    void OndeDeChoc()
    {
        if (Input.GetKeyUp(KeyCode.O) && player.currentMp > 0)
        {
            Rigidbody instance;
            instance = Instantiate(Onde_de_choc, transform.position, transform.rotation) as Rigidbody;
            player.currentMp -= OndeDeChocMana;
            player.usedMana = true;
            //instance.AddForce(transform.forward * force);
        }
    }

}
