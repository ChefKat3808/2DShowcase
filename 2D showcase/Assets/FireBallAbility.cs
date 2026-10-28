using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBallAbility : MonoBehaviour
{
    public GameObject FireBall;

    public float bulletSpeed = 6;
    public int charges = 3;
    public TMP_Text FBChargeText;
    public void Start()
    {
        FBChargeText.text = ("Charge: " + charges);
    }
    public void OnAbility()
    {

        if (charges > 0 && Time.timeScale == 1)
        {
            GameObject shot = Instantiate(FireBall, transform.position, Quaternion.identity);
            Destroy(shot, 10);
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            Debug.Log(mousePos);
            Vector3 shootDir = mousePos - transform.position;
            shootDir.Normalize();
            shot.GetComponent<Rigidbody2D>().linearVelocity = shootDir * bulletSpeed;
            charges -= 1;
            FBChargeText.text = ("Charge: " + charges);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "AmmoPack")
        {
            Debug.Log("I got Ammo pack!");
            charges = 3;
            FBChargeText.text = "Charge: " + charges;

            if (charges > 3)
            {
                Debug.Log("I have all my charges!");
                charges = 3;
                FBChargeText.text = "Charge: " + charges;

            }


        }
    }
}