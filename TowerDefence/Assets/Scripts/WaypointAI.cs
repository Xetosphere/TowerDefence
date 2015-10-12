using UnityEngine;
using System.Collections;

public enum Direction
{
    Up, Right, Down, Left
};

public class WaypointAI : MonoBehaviour {

    // Public

    public GameObject[] waypoints;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float attackSpeed = 1.0f;

    public string waypointTag = "Waypoint";

    public Direction defaultDirection = Direction.Down;

    // Private
    Transform targetWaypoint;
    Animator anim;

    bool isMoving = false;

    int currentWaypoint = 0;

    Direction dir;

    void Start()
    {
        anim = transform.GetComponent<Animator>();

        waypoints = GameObject.FindGameObjectsWithTag(waypointTag);
        dir = defaultDirection;
    }

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            isMoving = true;
            for (int i = 0; i < waypoints.Length; i++)
            {
                WaypointScript script = waypoints[i].GetComponent<WaypointScript>();

                if (script.queuePosition == currentWaypoint)
                {
                    targetWaypoint = waypoints[i].transform;
                }
            }

            if (targetWaypoint != null)
            {
                if (transform.position.y < targetWaypoint.position.y)
                    dir = Direction.Up;
                else if (transform.position.y > targetWaypoint.position.y)
                    dir = Direction.Down;
                else if (transform.position.x < targetWaypoint.position.x)
                    dir = Direction.Right;
                else if (transform.position.x > targetWaypoint.position.x)
                    dir = Direction.Left;

                Move(targetWaypoint.position);

                float distance = Vector2.Distance(transform.position, targetWaypoint.position);
                
                if (distance <= 0f)
                    currentWaypoint++;
            }
        }
        else
        {
            isMoving = false;
        }
    }

    void ApplyCorrectAnimation(Direction direction)
    {
        anim.SetInteger("Direction", (int)direction);
        anim.SetBool("isMoving", isMoving);
    }

    void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
