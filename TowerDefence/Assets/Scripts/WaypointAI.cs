using UnityEngine;
using System.Collections;

public class WaypointAI : MonoBehaviour {

    // Public

    public GameObject[] waypoints;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 5.0F;

    public string waypointTag = "Waypoint";

    // Private
    int currentWaypoint = 0;
    Transform targetWaypoint;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag(waypointTag);
    }

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
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

                Move(targetWaypoint.position);

                float distance = Vector2.Distance(transform.position, targetWaypoint.position);
                
                if (distance < 0.001f)
                    currentWaypoint++;
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
