using Pathfinding;
using UnityEngine;

public class PlayerdetectorAI : MonoBehaviour {

    public Transform target;
    public Transform player;          // Drag your Player object here in the inspector
    public float chaseRange = 5f;     // How close the player must be to trigger a chase
    public float moveSpeed = 3f;


    IAstarAI ai;

    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        // Update the destination right before searching for a path as well.
        // This is enough in theory, but this script will also update the destination every
        // frame as the destination is used for debugging and may be used for other things by other
        // scripts as well. So it makes sense that it is up to date every frame.
        if (ai != null) ai.onSearchPath += Update;
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }


    void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
        //create your own new AI destination script thart will make the enemy chase the player IF the player
        //is close
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the distance is less than or equal to the chase range
        if (distanceToPlayer <= chaseRange)
        {
            // Move towards the player's position
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime);
    }
    }
}

