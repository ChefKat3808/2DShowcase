using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyHealthV2 : MonoBehaviour

{
    public int health = 2;
    public GameObject healthPack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.gameObject.tag == "FireBall")
        {
            Debug.Log(":I hit an enemy");
            health -= 5;
            if (health <= 0)

            {
                Debug.Log("I killed an enemy!");
                Destroy(gameObject);
                int r = Random.Range(1, 15);
                if (r >= 5)
                  
                    Instantiate(healthPack, transform.position, Quaternion.identity);
            }
        }
    }
}
