using Unity.VisualScripting;
using UnityEngine;

public class HealthPackDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D  (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
