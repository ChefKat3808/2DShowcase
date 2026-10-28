using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;

    public float bulletSpeed = 10;
 
   
    public void OnAttack()
    {

        if (Time.timeScale == 1)
        {
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(shot, 10);
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Debug.Log(mousePos);
            Vector3 shootDir = mousePos - transform.position;
            shootDir.Normalize();
            shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;
            
        }
    }
   
}
