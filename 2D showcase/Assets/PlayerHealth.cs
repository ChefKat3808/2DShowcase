using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour

{
    //Store hp in a variable
    //If we hit an enemy, reduce my hp
    //When you lose all hp, you die.
    //When we die, reload current level
    public int health = 100;
    public TMP_Text healthText;


    void Start()
    {
        healthText.text = "Health: " + health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // double == co,apres the values to give true or false
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit an enemy!");
            health -= 10;
            healthText.text = "Health: " + health;
            if (health <= 0)
            {
                Debug.Log("I'm dead!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);



                if (collision.gameObject.tag == "HealthPack")
                {
                    Debug.Log("I got health pack!");
                    health += 10;
                    healthText.text = "Health: " + health;

                    if (health > 100)
                    {
                        Debug.Log("Im Full!");
                        health = 100;
                        healthText.text = "Health: " + health;

                    }



                }
            }
        }
    }
}

