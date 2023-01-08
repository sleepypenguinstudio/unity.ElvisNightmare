using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int currentHealth = 100;
    public Slider healthBar;
    public static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver= false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;

        if(currentHealth < 0)
        {
            gameOver = true;
        }
    }
}
