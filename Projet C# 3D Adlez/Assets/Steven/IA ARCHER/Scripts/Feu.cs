using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().currentHp -= 1;
            other.gameObject.GetComponent<Enemy>().isDamaged = true;

        }
    }

}
