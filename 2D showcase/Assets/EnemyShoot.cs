using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 5;
    public float shootDelay = 3;
    float timer = 0;
    public float shootTriggerDistance = 5;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }
    void Update()
    {
            timer += Time.deltaTime;
        if(timer> shootDelay)
        {
            Vector3 shootDir = player.transform.position - transform.position;
            if(shootDir.magnitude < shootTriggerDistance)
            {
                timer = 0;
                GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
                shootDir.Normalize();
                shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;
                Destroy(shot, 10);
            }

        }
    }
}
