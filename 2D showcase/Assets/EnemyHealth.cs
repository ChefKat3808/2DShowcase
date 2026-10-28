using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 2;
    public GameObject healthPack;
    

    // store hp as a variable
    //if the enemy hits a player bullet, reduce hp
    //if hp <= 0, they die
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    //this function does not run for trigger collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.gameObject.tag == "Bullet")
        {
            Debug.Log(":I shot an enemy!");
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("I killed an enemy!");
                Destroy(gameObject);
                int r = Random.Range(1, 15);
                if (r >= 5)
                    Instantiate(healthPack, transform.position, Quaternion.identity);
               
                if (collision.gameObject.gameObject.tag == "FireBall")
                {
                    Debug.Log(":I hit an enemy");
                    health -= 5;
                    if (health <= 0)
                    {
                        Debug.Log("I killed an enemy!");
                        Destroy(gameObject);

                        if (r >= 5)
                           
                            Instantiate(healthPack, transform.position, Quaternion.identity);
                    }
                    // CHALLENGE:
                    //modify enemy health to have a CHANCE of dropping a health pack object on death
                    //create a new script on the player bullet to DESTROY the player bullet 
                    //when it hits anything whose tag != (this means NOT equal) to the player
                }
            }

            //this function does run on trigger collisions
        }
    }
}
