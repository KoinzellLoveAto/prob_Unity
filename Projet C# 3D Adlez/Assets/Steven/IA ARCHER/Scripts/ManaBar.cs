using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider; // Composant qui permet de graduer la barre de point de vie
    //public Gradient gradient; // Composant qui permet d'afficher la couleur selon le %
    public Image fill; // L'image qui permet de remplir la barre de point de vie

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // à utiliser lors du début du jeu pour définir les hp max
    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

       // fill.color = gradient.Evaluate(1f);
    }

    // à utiliser à chaque fois qu'on influe les pv afin que la barre d'hp suive
    public void SetMana(int mana)
    {
        slider.value = mana;

        // fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
