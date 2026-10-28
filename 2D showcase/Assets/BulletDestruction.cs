using UnityEngine;

public class BulletDestruction : MonoBehaviour
{

    //create a new script on the player bullet to DESTROY the player bullet
    //when it hits anything whose tag != (this means NOT equal) to the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}

