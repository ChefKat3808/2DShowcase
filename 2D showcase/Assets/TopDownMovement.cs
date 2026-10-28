using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    // First we need to get user input
    //then we need to push the player in the direction of the input
    public float moveSpeed = 2f;
    public void OnMove(InputValue value)
    {
        //Vector 2 is a special variable meant to store 2 floats (x, y)
        Vector2 moveDir = value.Get<Vector2>();
        // If I press the W key, Vector2 = (0,1)
        //If I press the A key, Vector = (-1, 0) etc 
        GetComponent<Rigidbody2D>().linearVelocity = moveDir * moveSpeed;

    }
}
